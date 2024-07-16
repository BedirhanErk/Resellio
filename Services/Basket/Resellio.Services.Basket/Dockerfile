FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Resellio.Shared/*.csproj Shared/Resellio.Shared/
COPY Services/Basket/Resellio.Services.Basket/*.csproj Services/Basket/Resellio.Services.Basket/
RUN dotnet restore Services/Basket/Resellio.Services.Basket/*.csproj
COPY . .
RUN dotnet publish Services/Basket/Resellio.Services.Basket/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Resellio.Services.Basket.dll" ]