FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Shelter.API/Shelter.API.csproj", "Shelter.API/"]
COPY ["src/Shelter.Application/Shelter.Application.csproj", "Shelter.Application/"]
COPY ["src/Shelter.Infrastructure/Shelter.Infrastructure.csproj", "Shelter.Infrastructure/"]
COPY ["src/Shelter.Shared/Shelter.Shared.csproj", "Shelter.Shared/"]
COPY "Directory.Build.props" "Directory.Build.props"
COPY "Directory.Packages.props" "Directory.Packages.props"
RUN dotnet restore --runtime linux-musl-x64 "./Shelter.API/Shelter.API.csproj"
COPY . .
WORKDIR "/src/Shelter.API"
RUN dotnet build "./Shelter.API.csproj" -c $BUILD_CONFIGURATION --runtime linux-musl-x64 -o /app/build 

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Shelter.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --runtime linux-musl-x64

FROM scratch AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["/app/Shelter.API"]