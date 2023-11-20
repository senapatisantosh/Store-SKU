FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

RUN mkdir /app/dropbox && chown -R app /app/dropbox

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Store.Api.Ingestion.csproj", "."]
RUN dotnet restore "./Store.Api.Ingestion.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Store.Api.Ingestion.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Store.Api.Ingestion.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER app

ENTRYPOINT ["dotnet", "Store.Api.Ingestion.dll"]
