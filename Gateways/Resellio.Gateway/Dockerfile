FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Gateways/Resellio.Gateway/*.csproj Gateways/Resellio.Gateway/
RUN dotnet restore Gateways/Resellio.Gateway/*.csproj
COPY . .
RUN dotnet publish Gateways/Resellio.Gateway/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Resellio.Gateway.dll" ]