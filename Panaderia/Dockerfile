FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiamos todo el repositorio respetando la estructura de carpetas
COPY . .

# 2. Restauramos los paquetes NuGet de toda la solución
RUN dotnet restore

# 3. Nos movemos EXACTAMENTE a la carpeta del proyecto Blazor
# Usamos "presentation" en minúscula tal cual lo vimos en los pasos anteriores
WORKDIR "/src/presentation/Panaderia.Blazor"

# 4. Publicamos forzando a que use la carpeta de salida correcta
RUN dotnet publish -c Release -o /app/output

# 5. Imagen final de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiamos los archivos compilados que AHORA SÍ van a estar ahí
COPY --from=build /app/output .

ENV ASPNETCORE_HTTP_PORTS=10000
ENV ASPNETCORE_URLS=http://*:10000
ENV ASPNETCORE_ENVIRONMENT=Production

# Volvemos a colocar el nombre directo, ya que ahora sí se va a generar el archivo
ENTRYPOINT ["dotnet", "Panaderia.Blazor.dll"]