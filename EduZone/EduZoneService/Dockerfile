# Base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage with SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["EduZoneService/EduZoneService.csproj", "EduZoneService/"]
COPY ["EduZone.Domain/EduZone.Domain.csproj", "EduZone.Domain/"]
COPY ["EduZone.Application/EduZone.Application.csproj", "EduZone.Application/"]
RUN dotnet restore "./EduZoneService/EduZoneService.csproj"

# Copy the rest of the source code
COPY . .
WORKDIR "/src/EduZoneService"

# Build the project
RUN dotnet build "./EduZoneService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Run migrations during the publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/EduZoneService

# Add EF Tools to the PATH
RUN dotnet tool install --global dotnet-ef

# Ensure the global tools path is in the PATH environment variable
ENV PATH="$PATH:/root/.dotnet/tools"

# Run migrations
RUN dotnet ef migrations add InitialMigration --project ../EduZone.Domain --startup-project . --output-dir ../EduZone.Domain/Migrations
RUN dotnet ef database update --project ../EduZone.Domain --startup-project .

# Publish the application
RUN dotnet publish "./EduZoneService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage for production
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduZoneService.dll"]
