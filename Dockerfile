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
# dotnet just require kerberos (it is authentication protocol in linux)
RUN apt-get update \
	&& apt-get install -y --no-install-recommends libgssapi-krb5-2 \
	&& rm -rf /var/lib/apt/lists/*
COPY --from=build /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "EazyTrade.dll"]