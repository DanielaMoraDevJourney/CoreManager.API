# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo el código
COPY . .

# Publica el proyecto en modo Release
RUN dotnet publish CoreManager.API.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia los archivos del build
COPY --from=build /app/publish .

# Configura el puerto y la URL de escucha
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Inicia la aplicación
ENTRYPOINT ["dotnet", "CoreManager.API.dll"]
