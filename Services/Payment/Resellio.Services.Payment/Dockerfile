FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Resellio.Shared/*.csproj Shared/Resellio.Shared/
COPY Services/Payment/Resellio.Services.Payment/*.csproj Services/Payment/Resellio.Services.Payment/
RUN dotnet restore Services/Payment/Resellio.Services.Payment/*.csproj
COPY . .
RUN dotnet publish Services/Payment/Resellio.Services.Payment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Resellio.Services.Payment.dll" ]