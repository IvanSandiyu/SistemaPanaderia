FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .
# Forzamos a .NET a escuchar en el puerto que Render quiere
ENV ASPNETCORE_HTTP_PORTS=10000
# Le decimos a .NET que corra en modo producción
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Panaderia.WebApi.dll"]