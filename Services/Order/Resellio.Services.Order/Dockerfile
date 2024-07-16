FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Resellio.Shared/*.csproj Shared/Resellio.Shared/
COPY Services/Order/Resellio.Services.Order.Application/*.csproj Services/Order/Resellio.Services.Order.Application/
COPY Services/Order/Resellio.Services.Order.Domain/*.csproj Services/Order/Resellio.Services.Order.Domain/
COPY Services/Order/Resellio.Services.Order.Domain.Core/*.csproj Services/Order/Resellio.Services.Order.Domain.Core/
COPY Services/Order/Resellio.Services.Order.Infrastructure/*.csproj Services/Order/Resellio.Services.Order.Infrastructure/
COPY Services/Order/Resellio.Services.Order/*.csproj Services/Order/Resellio.Services.Order/
RUN dotnet restore Services/Order/Resellio.Services.Order/*.csproj
COPY . .
RUN dotnet publish Services/Order/Resellio.Services.Order/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Resellio.Services.Order.dll" ]