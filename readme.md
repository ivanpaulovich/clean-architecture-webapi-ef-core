# [![Try in PWD](https://raw.githubusercontent.com/play-with-docker/stacks/master/assets/images/button.png)](https://labs.play-with-docker.com/?stack=https://raw.githubusercontent.com/ivanpaulovich/clean-architecture-webapi-ef-core/master/source/docker-compose.yml&stack_name=clean-architecture-webapi-ef-core) Clean Architecture Implementation of a Personal Wallet Web Api

The simplest demo on how to implement a Web Api using .NET Core and Entity Framework that protects the business rules from framework dependencies by following the Clean Architecture Principles.

## :whale: Running From The Docker Image

```sh
docker run -e ASPNETCORE_ENVIRONMENT="Development" -p 5500:80 ivanpaulovich/clean-architecture-webapi-ef-core
```

## :rocket: Running From Source

To run on top of a InMemory persistance layer simple run:

```sh
dotnet run --environment="dev" --project source/MyWallet.WebApi/MyWallet.WebApi.csproj
```

To run on top of a SQL Server persistance layer you need to setup the SQL Server database in steps ahead then run:

```sh
dotnet run --environment="production" --project source/MyWallet.WebApi/MyWallet.WebApi.csproj
```

Then navigate to the Swagger URL `http://localhost:5500/` or run in command-line:

```sh
curl -X POST "http://localhost:5500/api/Customers" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -d "{ \"personnummer\": \"198608178877\", \"name\": \"string\", \"initialAmount\": 440}"
```

## :floppy_disk: SQL Server Database

If you wanna use Entity Framework, setup the SQL Server then update the database via dotnet EF Tool.

### Update the Database

```sh
dotnet ef database update --project source/MyWallet.Infrastructure --startup-project source/MyWallet.WebApi
```

### Add Migration

Run the EF Tool to add a migration to the `MyWallet.Infrastructure` project.

```sh
dotnet ef migrations add "InitialCreate" -o "EntityFrameworkDataAccess/Migrations" --project source/MyWallet.Infrastructure --startup-project source/MyWallet.WebApi
```

### Setup the SQL Server in Docker

To run SQL Server container images with Docker use:

```sh
#!/bin/bash
sudo docker pull mcr.microsoft.com/mssql/server:2017-latest
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<YourStrong!Passw0rd>' -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest
sudo docker exec -it sql1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '<YourStrong!Passw0rd>' -Q 'ALTER LOGIN SA WITH PASSWORD="<YourNewStrong!Passw0rd>"'
```

It will enable a SQL Server running on `Server=localhost;User Id=sa;Password=<YourNewStrong!Passw0rd>;` for more details checkout the docs at [How to run a SQL Server in a Docker Container](https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-2017).

## :checkered_flag: Requirements

Developed and Tested using:

* MacOS Sierra
* VSCode :heart:
* [.NET SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2).
* Docker :whale:
* SQL Server via Docker container.

## :telephone: For Support and Issues

I am happy to be reach out through the **Issues Tab**.
