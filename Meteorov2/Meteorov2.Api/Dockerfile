# ETAPA 1: Compilación (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos el archivo de proyecto de la API (estamos dentro de /Meteorov2.Api)
COPY ["Meteorov2.Api.csproj", "Meteorov2.Api/"]

# IMPORTANTE: Para que Docker encuentre las otras capas estando el contexto en la API,
# debemos copiar las carpetas completas de las dependencias.
COPY ["../Meteorov2.Application/", "Meteorov2.Application/"]
COPY ["../Meteorov2.Domain/", "Meteorov2.Domain/"]
COPY ["../Meteorov2.Infrastructure/", "Meteorov2.Infrastructure/"]

# Restauramos dependencias
RUN dotnet restore "Meteorov2.Api/Meteorov2.Api.csproj"

# Copiamos todo el contenido de la API
COPY . ./Meteorov2.Api/

# Compilamos
WORKDIR "/src/Meteorov2.Api"
RUN dotnet build "Meteorov2.Api.csproj" -c Release -o /app/build

# ETAPA 2: Publicación
FROM build AS publish
RUN dotnet publish "Meteorov2.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ETAPA 3: Ejecución Final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Puerto interno de Docker
EXPOSE 8080

ENTRYPOINT ["dotnet", "Meteorov2.Api.dll"]