# Building api and ui
Run following commands from *src* folder.
* ```docker build -f api/Dockerfile -t nisal/api .```
* ```docker build -f web/Dockerfile -t nisal/web .```

# Running the setup
 Run ```docker-compose up``` from src folder

# Run SQL Server from docker container
* sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<<password>>" -p 1433:1433 --name sql1 -h sql1 -d mcr.microsoft.com/mssql/server:2019-latest
* connection string **Server=localhost,1433;Database=master;User Id=SA;Password=<<password>>;**
* connecting to **sqlcmd** 
    1. run ```sudo docker exec -it sql1 "bash"```
    2. then run ```/opt/mssql-tools/bin/sqlcmd -S localhost:1433 -U SA -P "1qaz2wsx@"```

# Working with migrations
Run within src/api folder.
* Remove
```dotnet ef migrations add {{name for the migration}} --project dataaccess/dataaccess.csproj --startup-project api/api.csproj```
* Remove
```dotnet ef migrations remove --project dataaccess/dataaccess.csproj --startup-project api/api.csproj```

# Changing the db provider
for example switch from MS SQL to Postgres SQL
* add package
```dotnet add api.csproj package Npgsql.EntityFrameworkCore.PostgreSQ```
* change startup.cs
```
services.AddDbContext<ProductDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("ProductContext"),
                    b => b.MigrationsAssembly("dataaccess")));
```
* remove migration change data types in entity config and add a new migration.
* modify docker-compose to run postgres sql image
* Change connection string in appsettings.json to following format
```Host=sqlserver;Port=5432;Database=products;User ID=SA;Password=1qaz2wsx@;```