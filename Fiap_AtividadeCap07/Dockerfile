# Etapa base (imagem de runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia apenas o .csproj e restaura dependências
COPY ["Fiap_AtividadeCap07/Fiap_AtividadeCap07.csproj", "Fiap_AtividadeCap07/"]
RUN dotnet restore "Fiap_AtividadeCap07/Fiap_AtividadeCap07.csproj"

# Copia o restante dos arquivos e compila
COPY . .
WORKDIR "/src/Fiap_AtividadeCap07"
RUN dotnet build "Fiap_AtividadeCap07.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Fiap_AtividadeCap07.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap_AtividadeCap07.dll"]
