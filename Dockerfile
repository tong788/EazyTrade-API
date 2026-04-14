# Build image
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY EazyTrade.csproj ./
RUN dotnet restore EazyTrade.csproj
COPY . .
RUN dotnet publish EazyTrade.csproj -c Release -o /app/publish --no-restore

# Runtime image (lighter weight)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EazyTrade.dll"]