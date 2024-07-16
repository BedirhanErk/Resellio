FROM mcr.microsoft.com/dotnet/sdk:8.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Resellio.Shared/*.csproj Shared/Resellio.Shared/
COPY Services/Catalog/Resellio.Services.Catalog/*.csproj Services/Catalog/Resellio.Services.Catalog
RUN dotnet restore Services/Catalog/Resellio.Services.Catalog/*.csproj
COPY . .
RUN dotnet publish Services/Catalog/Resellio.Services.Catalog/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Resellio.Services.Catalog.dll" ]