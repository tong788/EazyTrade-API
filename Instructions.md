<!-- migration steps -->

1. dotnet ef migrations add <MigrationName>
2. dotnet ef database update

<!-- scaffold -->

dotnet ef dbcontext scaffold "Host=localhost;Database=YourDbName;Username=YourUser;Password=YourPassword" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models --context-dir Data --context ApplicationDBContext --force