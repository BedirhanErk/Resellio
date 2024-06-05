﻿using Mentor.Web.Handler;
using Mentor.Web.Models;
using Mentor.Web.Services;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Extensions
{
    public static class ServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var serviceApiSettings = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            builder.Services.AddHttpClient<ICatalogService, CatalogService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUri}/{serviceApiSettings.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IPhotoStockService, PhotoStockService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUri}/{serviceApiSettings.PhotoStock.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            builder.Services.AddHttpClient<IUserService, UserService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.IdentityUri);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayUri}/{serviceApiSettings.Basket.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            builder.Services.AddHttpClient<IIdentityService, IdentityService>();
            builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
        }
    }
}