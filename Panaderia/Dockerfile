FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiamos todo el repositorio
COPY . .

# 2. Restauramos paquetes
RUN dotnet restore

# 3. Compilamos el proyecto Blazor apuntando a su .csproj
RUN dotnet publish **/Panaderia.Blazor.csproj -c Release -o /app/publish

# 4. Imagen de ejecución (usamos 8.0 que es el framework que detectamos antes)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# CONFIGURACIÓN CLAVE PARA EVITAR EL ERROR 145:
# Forzamos solo puerto HTTP y desactivamos la redirección a HTTPS dentro del contenedor
ENV ASPNETCORE_HTTP_PORTS=10000
ENV ASPNETCORE_URLS=http://+:10000
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Panaderia.Blazor.dll"]