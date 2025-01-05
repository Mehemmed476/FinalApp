# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["FinalApp.sln", "./"]
COPY ["FinalApp.API/FinalApp.API.csproj", "FinalApp.API/"]
COPY ["FinalApp.BL/FinalApp.BL.csproj", "FinalApp.BL/"]
COPY ["FinalApp.DAL/FinalApp.DAL.csproj", "FinalApp.DAL/"]
COPY ["FinalApp.Core/FinalApp.Core.csproj", "FinalApp.Core/"]

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Build and publish
RUN dotnet publish "FinalApp.API/FinalApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
USER $APP_UID
ENTRYPOINT ["dotnet", "FinalApp.API.dll"] 