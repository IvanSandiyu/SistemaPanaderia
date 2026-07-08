FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiamos todo el repositorio
COPY . .

# 2. Restauramos paquetes NuGet de la solución
RUN dotnet restore

# 3. Publicamos el proyecto Blazor apuntando a su raíz de compilación
WORKDIR "/src"
RUN dotnet publish **/Panaderia.Blazor.csproj -c Release -o /app/output

# 4. Imagen final de ejecución (cambiamos al directorio de trabajo limpio)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiamos todo el contenido publicado (incluyendo el wwwroot de Blazor)
COPY --from=build /app/output .

# Configuraciones de red explícitas para el ciclo de vida de Render
ENV ASPNETCORE_HTTP_PORTS=10000
ENV ASPNETCORE_URLS=http://*:10000
ENV ASPNETCORE_ENVIRONMENT=Production

# Forzamos a que el punto de inicio sea el ejecutable directo
ENTRYPOINT ["dotnet", "Panaderia.Blazor.dll"]