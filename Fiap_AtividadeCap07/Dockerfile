FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Fiap_AtividadeCap07/Fiap_AtividadeCap07.csproj", "Fiap_AtividadeCap07/"]
RUN dotnet restore "Fiap_AtividadeCap07/Fiap_AtividadeCap07.csproj"

COPY . . 
WORKDIR "/src/Fiap_AtividadeCap07"
RUN dotnet build "Fiap_AtividadeCap07.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap_AtividadeCap07.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 
ENTRYPOINT ["dotnet", "Fiap_AtividadeCap07.dll"]
