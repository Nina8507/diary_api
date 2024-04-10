# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Use the official ASP.NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["diary_api.csproj", "./"]
RUN dotnet restore "diary_api.csproj"

COPY . .
WORKDIR /src
RUN dotnet build "diary_api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the app
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "diary_api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Final stage/image
FROM base AS final
EXPOSE 8082
EXPOSE 8083
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "diary_api.dll"]
