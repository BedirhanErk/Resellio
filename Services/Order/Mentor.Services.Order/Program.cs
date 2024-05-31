using MediatR;
using Mentor.Services.Order.Infrastructure;
using Mentor.Shared.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OrderDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), configure =>
    {
        configure.MigrationsAssembly("Mentor.Services.Order.Infrastructure");
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddMediatR(typeof(Mentor.Services.Order.Application.Handlers.CreateOrderCommandHandler).Assembly);
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
