FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Resellio.Shared/*.csproj Shared/Resellio.Shared/
COPY Services/Discount/Resellio.Services.Discount/*.csproj Services/Discount/Resellio.Services.Discount/
RUN dotnet restore Services/Discount/Resellio.Services.Discount/*.csproj
COPY . .
RUN dotnet publish Services/Discount/Resellio.Services.Discount/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Resellio.Services.Discount.dll" ]