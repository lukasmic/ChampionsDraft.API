# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY "Directory.Build.props" "Directory.Build.props"
COPY "ChampionsDraft.API.sln" "ChampionsDraft.API.sln"
COPY "ChampionsDraft.API/ChampionsDraft.API.csproj" "ChampionsDraft.API/"
COPY "ChampionsDraft.Application/ChampionsDraft.Application.csproj" "ChampionsDraft.Application/"
COPY "ChampionsDraft.Contracts/ChampionsDraft.Contracts.csproj" "ChampionsDraft.Contracts/"
COPY "ChampionsDraft.Domain/ChampionsDraft.Domain.csproj" "ChampionsDraft.Domain/"
COPY "ChampionsDraft.Infrastructure/ChampionsDraft.Infrastructure.csproj" "ChampionsDraft.Infrastructure/"
RUN dotnet restore "./ChampionsDraft.API/ChampionsDraft.API.csproj"
COPY . .
WORKDIR "/src/ChampionsDraft.API"
RUN dotnet build "./ChampionsDraft.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ChampionsDraft.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChampionsDraft.API.dll"]