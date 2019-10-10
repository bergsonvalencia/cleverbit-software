# Cleverbit Software API

## Configurations

1. Make sure .NET Core 2.2 is installed on computer.

2. Open "CleverbitSoftware.sln" from "Web_Api_DotNetCore_2" folder.

3. Set "ASPNETCORE_ENVIRONMENT" value of "CleverbitSoftware.WebApi" project equal to "Development".

4. Set "DbConnection" in "appsettings.Development.json" equal to your MSSQL server instance.

## DB Migrations

1. Go to Tools > NuGet Package Manager > Package Manager Console

2. Set Default project: ArticleManagement.Infrastructure

3.  Add migration
```bash
Add-Migration InitialCreate
```

4. Update Database
```bash
Update-Database
```

## Run

1. Run the "CleverbitSoftware.WebApi" project.

2. Make sure the API is running on "https://localhost:44331", url should be in sync with the client app. Note that it is also running on https.
