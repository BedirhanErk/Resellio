FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Resellio.Shared/*.csproj Shared/Resellio.Shared/
COPY Services/PhotoStock/Resellio.Services.PhotoStock/*.csproj Services/PhotoStock/Resellio.Services.PhotoStock/
RUN dotnet restore Services/PhotoStock/Resellio.Services.PhotoStock/*.csproj
COPY . .
RUN dotnet publish Services/PhotoStock/Resellio.Services.PhotoStock/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Resellio.Services.PhotoStock.dll" ]