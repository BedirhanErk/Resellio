using Mentor.Web.Exceptions;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Handler
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetToken());

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new UnAuthorizeException();

            return response;
        }
    }
}
