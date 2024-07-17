FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Resellio.Shared/*.csproj Shared/Resellio.Shared/
COPY Frontends/Resellio.Web/*.csproj Frontends/Resellio.Web/
RUN dotnet restore Frontends/Resellio.Web/*.csproj
COPY . .
RUN dotnet publish Frontends/Resellio.Web/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Resellio.Web.dll" ]