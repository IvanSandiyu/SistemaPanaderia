FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Copiamos la solución que está en la raíz
COPY *.sln ./

# 2. Copiamos los archivos .csproj respetando sus carpetas físicas
COPY core/Panaderia.Application/*.csproj ./core/Panaderia.Application/
COPY core/Panaderia.Domain/*.csproj ./core/Panaderia.Domain/

COPY infrastructure/Panaderia.Infrastructure.EntityFramework/*.csproj ./infrastructure/Panaderia.Infrastructure.EntityFramework/

COPY presentation/Panaderia.WebApi/*.csproj ./presentation/Panaderia.WebApi/

COPY Panaderia.Shared/*.csproj ./Panaderia.Shared/

COPY presentation/Panaderia.Blazor/*.csproj ./presentation/Panaderia.Blazor/

# 3. Restauramos los paquetes NuGet de toda la solución
RUN dotnet restore

# 4. Copiamos todo el código fuente respetando la estructura
COPY . .

# 5. Nos movemos a la carpeta de la API para compilar (respetando la carpeta Presentation)
WORKDIR "/src/presentation/Panaderia.WebApi"
RUN dotnet publish -c Release -o /app/publish

# 6. Imagen final de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=10000
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Panaderia.WebApi.dll"]