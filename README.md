# OMS - GRPC

### Description

This project implements a high-performance Order Management System (OMS) using gRPC for communication between services. It allows creating, updating, listing, and managing orders along with their associated order items. The system supports filters, pagination, and efficient database queries using Entity Framework Core.

Key features include:

- **Order CRUD operations** – Create, Read, Update, Delete orders.
- **Order Item management** – Each order can contain multiple order items.
- **Filters & Pagination** – List orders by status, product code, product name, with paginated responses.
- **High-performance gRPC APIs** – Ensures low-latency communication between microservices.
- **Database integration** – Built with Entity Framework Core and a relational database (SQL Server/PostgreSQL).
- **Asynchronous operations** – All queries and commands are async for scalability.

### Tech Stack

| Layer                    | Technology / Library                   | Purpose                                    |
| ------------------------ | -------------------------------------- | ------------------------------------------ |
| **Backend**              | .NET 8 / C#                            | Core application development               |
| **gRPC**                 | Grpc.AspNetCore                        | Service-to-service communication           |
| **Database**             | Entity Framework Core                  | ORM for database interaction               |
| **Database**             | SQL Server / PostgreSQL                | Relational database for persistent storage |
| **Logging**              | Serilog / Microsoft.Extensions.Logging | Structured logging for diagnostics         |
| **Dependency Injection** | Built-in .NET DI                       | Managing services and repositories         |
| **Version Control**      | Git                                    | Source code management                     |

## Installed packages for GRPC

```bash
dotnet add package Grpc.Net.Client
dotnet add package Google.Protobuf
dotnet add package Grpc.Tools
```

## Global tool for GRPC

```bash
dotnet tool install --global dotnet-grpc
```

## Setup locally:

1. Clone the Repository:

   ```bash
   git clone https://github.com/Sahil2k07/OMS-gRPC.git
   ```

2. Change Directory:

   ```bash
   cd OMS-gRPC
   ```

3. Configure your appsettings.json with SQL Server connection string and JWT settings:

   ```json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "DbSettings": {
       "Host": "localhost",
       "Database": "OMS",
       "User": "SA",
       "Password": "$hahil00"
     },
     "JwtSettings": {
       "TokenName": "oms-token",
       "SecretKey": "aP7s9vE1xY4rT0zLqW8mNjHbCdFgUkIr",
       "Issuer": "http://localhost:5205",
       "Audience": "oms-local",
       "ExpiryHours": 24
     },
     "GrpcSettings": {
       "ServiceAddress": "http://localhost:6000",
       "ServiceToken": "5763121b0c2141eb73d3c1ddfe65a02f30e56adc2fd6f62d1a143f38dc1f3680"
     }
   }
   ```

4. Restore all the packages first:

   ```bash
   cd oms-core

   dotnet restore
   ```

5. Access to your local SQL-Server and create a database

   ```sql
   CREATE DATABASE OMS
   ```

6. Add the DB Creds in `oms-core/migration.json` file as well as it will be needed to run migraion

   ```json
   {
     "DbSettings": {
       "Host": "localhost",
       "Database": "OMS",
       "User": "SA",
       "Password": "$hahil00"
     }
   }
   ```

7. Run EF Core migrations to create/update the database schema:

   ```bash
   dotnet ef database update

   cd ..
   ```

8. Generate the Grpc services code:

   ```bash
   cd oms-web

   dotnet build
   ```

9. Run the migration:

   ```bash

   ```

10. Run the app in Development mode:

    ```bash
    dotnet run
    ```

11. Additionally you can make the Release build of the project using the command

    ```bash
    dotnet publish -c Release
    ```

- You can find the release build in the location `oms-web/bin/Release/net8.0/publish`
