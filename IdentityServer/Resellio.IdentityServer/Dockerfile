FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Resellio.Shared/*.csproj Shared/Resellio.Shared/
COPY IdentityServer/Resellio.IdentityServer/*.csproj IdentityServer/Resellio.IdentityServer/
RUN dotnet restore IdentityServer/Resellio.IdentityServer/*.csproj
COPY . .
RUN dotnet publish IdentityServer/Resellio.IdentityServer/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Resellio.IdentityServer.dll" ]