using MassTransit;
using Resellio.Services.Basket.Consumers;
using Resellio.Services.Basket.Services;
using Resellio.Services.Basket.Settings;
using Resellio.Shared.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(x => {

    x.AddConsumer<ProductChangedEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        cfg.ReceiveEndpoint("product-changed-event-basket", e =>
        {
            e.ConfigureConsumer<ProductChangedEventConsumer>(context);
        });
    });
});

builder.Services.AddMassTransitHostedService();

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = "resource_basket";
    options.RequireHttpsMetadata = false;
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));

builder.Services.AddSingleton<RedisService>(sp =>
{
    var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redisSettings.Host, redisSettings.Port);
    redis.Connect();
    return redis;
});

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
