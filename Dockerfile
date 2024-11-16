# Usa la imagen base oficial de ASP.NET para aplicaciones en producción
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Usa la imagen base oficial de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TallerModel.csproj", "./"]
RUN dotnet restore "./TallerModel.csproj"

# Copia el resto del código y compílalo
COPY . .
WORKDIR "/src/."
RUN dotnet build "TallerModel.csproj" -c Release -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish "TallerModel.csproj" -c Release -o /app/publish

# Crea la imagen final para correr la aplicación
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TallerModel.dll"]
