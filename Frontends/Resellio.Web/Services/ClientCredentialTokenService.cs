using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Resellio.Web.Models;
using Resellio.Web.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Resellio.Web.Services
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly ClientSettings _clientSettings;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;

        public ClientCredentialTokenService(HttpClient httpClient, IOptions<ServiceApiSettings> serviceApiSettings, IOptions<ClientSettings> clientSettings, IClientAccessTokenCache clientAccessTokenCache)
        {
            _httpClient = httpClient;
            _serviceApiSettings = serviceApiSettings.Value;
            _clientSettings = clientSettings.Value;
            _clientAccessTokenCache = clientAccessTokenCache;
        }

        public async Task<string> GetToken()
        {
            var currentToken = await _clientAccessTokenCache.GetAsync("WebClientToken", default);

            if (currentToken != null)
                return currentToken.AccessToken;

            var disco = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityUri,
                Policy = new DiscoveryPolicy { RequireHttps = false }
            });

            if (disco.IsError)
                throw disco.Exception;

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest();
            clientCredentialTokenRequest.ClientId = _clientSettings.WebClient.ClientId;
            clientCredentialTokenRequest.ClientSecret = _clientSettings.WebClient.ClientSecret;
            clientCredentialTokenRequest.Address = disco.TokenEndpoint;

            var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            if (newToken.IsError)
                throw newToken.Exception;

            await _clientAccessTokenCache.SetAsync("WebClientToken", newToken.AccessToken, newToken.ExpiresIn, default);

            return newToken.AccessToken;
        }
    }
}
