FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiamos todo el repositorio
COPY . .

# 2. Restauramos paquetes NuGet
RUN dotnet restore

# 3. Publicamos el proyecto Blazor apuntando a su .csproj
RUN dotnet publish **/Panaderia.Blazor.csproj -c Release -o /app/output

# 4. Imagen final de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiamos todo el contenido publicado
COPY --from=build /app/output .

# Configuraciones de red para Render
ENV ASPNETCORE_HTTP_PORTS=10000
ENV ASPNETCORE_URLS=http://*:10000
ENV ASPNETCORE_ENVIRONMENT=Production

# TRUCO DEFINITIVO: Buscamos la DLL principal dinámicamente para que no falle por el nombre
ENTRYPOINT ["sh", "-c", "dotnet $(ls *.runtimeconfig.json | cut -d'.' -f1-2).dll"]