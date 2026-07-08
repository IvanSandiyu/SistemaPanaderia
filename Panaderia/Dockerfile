FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiamos la solución y todos los archivos .csproj para restaurar dependencias
COPY *.sln ./
COPY Panaderia.WebApi/*.csproj ./Panaderia.WebApi/
COPY Panaderia.Blazor/*.csproj ./Panaderia.Blazor/
COPY Panaderia.Application/*.csproj ./Panaderia.Application/
COPY Panaderia.Domain/*.csproj ./Panaderia.Domain/
COPY Panaderia.Shared/*.csproj ./Panaderia.Shared/
COPY Panaderia.Infrastructure.EntityFramework/*.csproj ./Panaderia.Infrastructure.EntityFramework/

RUN dotnet restore

COPY . .
WORKDIR "/src/Panaderia.WebApi"
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=10000
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "Panaderia.WebApi.dll"]