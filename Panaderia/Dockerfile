FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiamos absolutamente todo el código y la estructura de carpetas
COPY . .

# 2. Restauramos los paquetes NuGet de toda la solución 
RUN dotnet restore

# 3. Compilamos la API buscando el archivo .csproj directamente donde sea que esté
RUN dotnet publish **/Panaderia.WebApi.csproj -c Release -o /app/publish

# 4. Imagen final de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=10000
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Panaderia.Blazor.dll"]