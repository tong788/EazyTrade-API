<!-- migration steps -->

1. dotnet ef migrations add <MigrationName>
2. dotnet ef database update

<!-- scaffold -->

dotnet ef dbcontext scaffold "Host=localhost;Database=YourDbName;Username=YourUser;Password=YourPassword" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models --context-dir Data --context ApplicationDBContext --force --no-onconfiguring

<!-- docker build image -->

1. go to root folder
2. docker build -t eazytrade-api:[tag] . #tag as a version

<!-- docker compose -->
1. go to root folder
2. docker compose up -d --build

<!-- when needed to restore db from local to container -->
docker compose --profile tools run --rm db-restore