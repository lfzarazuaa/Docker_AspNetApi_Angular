# Mdm Project with SQL SERVER, ASP.NET Web API, and Angular

## DB Config

The database setup requires only running the container and specifying the local storage path. This can be adjusted in the `.env` file under `SQL_VOLUME_PATH`. To change the password, modify `MSSQL_SA_PASSWORD`.

## ASP.NET Web API

The Web API is developed in C# using ASP.NET. For developers, `docker-compose.yml` is recommended as it runs the API in a container equipped with all necessary tools to add new packages. The .NET SDK is installed, and the source files are present within the container. To manually start the API server, uncomment `#command: ["bash"]` in `docker-compose.yml` and run `dotnet run`. If you want the API to start automatically, leave `command: ["bash"]` commented.

- Test the API using the following endpoints:
  - [https://localhost:5001/](https://localhost:5001/)
  - [https://localhost:5001/WeatherForecast](https://localhost:5001/WeatherForecast)
  - [https://localhost:5001/WeatherForecast/ByPlace](https://localhost:5001/WeatherForecast/ByPlace)
  - [https://localhost:5001/WeatherForecast/test-sql-connection](https://localhost:5001/WeatherForecast/test-sql-connection)

## Angular 15 UI

The user interface (UI) is web-based and developed in Angular, connecting to the ASP.NET API.

- Access the UI at the following endpoints:
  - Development: [http://localhost:4200](http://localhost:4200/)
  - Production: [http://localhost:1080](http://localhost:1080/)

## Running the Solution

Before running the solution in either development or production mode, ensure you've set up your environment variables properly:

1. Copy the ``.env.example`` to ``.env``:

    ```bash
    cp .env.example .env
    ```

2. If you are running the production mode, copy the ``.prod.env.example`` to ``.prod.env``:

    ```bash
    cp prod.env.example prod.env
    ```

3. Edit the ``.env`` and/or ``prod.env`` files to set the required environment variables. Ensure you follow the password rule for the database: "The password must be at least 8 characters long and contain characters from three of the following four sets: Uppercase letters, Lowercase letters, Base 10 digits, and Symbols."

4. Make sure to set the appropriate path for the host system you want to bind with, using the proper format, either Unix style (/path/to/dir) or Windows style (C:\path\to\dir).

### Development mode

For the ``development mode``, follow these steps:

1. Download the source code.
2. Build all the images (required when adding new packages or changing the order in the Dockerfile).

   ```bash
   docker-compose build --no-cache
    ```

3. Set the .env with the content of .dev.env (can be set only one time if not overriden).

    ```bash
    >> bash run_copy_env-dev.sh
    ```

4. Run all the containers.

    ```bash
    >> docker-compose up
    ```

5. Connect using Visual Studio Code's Remote Container feature.

6. Stop the services via the Docker UI or execute the following command:

    ```bash
    >> docker-compose down
    ```

### Production mode

For the ``production mode``, which is a lightweight version without dev tools:

1. Download the source code.
2. Build all the images (necessary when adding new packages or if the Dockerfile order changes).

    ```bash
    >> docker-compose -f docker-compose.prod.yml build --no-cache
    ```

3. Set the .env with the content of .prod.env (can be set only one time if not overriden).

    ```bash
    >> bash run_copy_env-prod.sh
    ```

4. Run all the containers.

    ```bash
    >> docker-compose -f docker-compose.prod.yml up
    ```

5. Connect using Visual Studio Code's Remote Container feature.

6. Stop the services via the Docker UI or use the command:

    ```bash
    >> docker-compose down
    ```

## Restoring SQL Server Databases from `.bak` Files

### Prerequisites

1. Download the backup for AdventureWorks2019 (OLTP) from [this link](https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks) or directly access the `.bak` file [here](https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2019.bak).

2. Ensure that the `.bak` file is placed in the directory specified by the `SQL_VOLUME_PATH` environment variable in your `.env`(prod or dev).

### Steps to Restore AdventureWorks2019 Database

1. **Start your containers**:

    Navigate to the directory containing your `docker-compose.yml`:

    ```bash
    docker-compose up -d
    ```

2. **Create Required Files and Assign Permissions**:

    Once the container is up and running, generate the necessary `.mdf` and `.ldf` files and assign permissions:

    ```bash
    docker exec -it your_sql_container_name bash -c "touch /var/opt/mssql/data/AdventureWorks2019.mdf && touch /var/opt/mssql/data/AdventureWorks2019_log.ldf"
    docker exec -it your_sql_container_name bash -c "chmod 777 /var/opt/mssql/data/AdventureWorks2019.mdf"
    docker exec -it your_sql_container_name bash -c "chmod 777 /var/opt/mssql/data/AdventureWorks2019_log.ldf"
    docker exec -it your_sql_container_name bash -c "chmod 777 /var/opt/mssql/data/AdventureWorks2019.bak"
    ```

3. **Choose Your Restoration Method**:

    a. Using a SQL Client (e.g., SSMS, Azure Data Studio):

    Connect to the SQL Server instance within the Docker container and run the following SQL script:

    ```sql
    USE [master]
    RESTORE DATABASE [AdventureWorks2019] FROM  DISK = N'/var/opt/mssql/data/AdventureWorks2019.bak' 
    WITH  FILE = 1,  
    MOVE N'AdventureWorks2019' TO N'/var/opt/mssql/data/AdventureWorks2019.mdf',  
    MOVE N'AdventureWorks2019_log' TO N'/var/opt/mssql/data/AdventureWorks2019_log.ldf',  
    NOUNLOAD,  REPLACE,  STATS = 5;
    GO
    ```

    b. Using `sqlcmd` within the Docker Container:

    Connect to the SQL Server container:

    ```bash
    docker exec -it your_sql_container_name /bin/bash
    ```

    Then, use `sqlcmd`:

    ```bash
    sqlcmd -S localhost -U SA -P '<YourPassword>' -Q "RESTORE DATABASE [AdventureWorks2019] FROM  DISK = N'/var/opt/mssql/data/AdventureWorks2019.bak' WITH  FILE = 1,  MOVE N'AdventureWorks2019' TO N'/var/opt/mssql/data/AdventureWorks2019.mdf',  MOVE N'AdventureWorks2019_log' TO N'/var/opt/mssql/data/AdventureWorks2019_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5;"
    ```

### Detailed Steps to Restore AdventureWorks2019Dev Database

1. **Prepare the Files**:

    Create the `.mdf` and `.ldf` files specific to the Dev version:

    ```bash
    docker exec -it your_sql_container_name bash -c "touch /var/opt/mssql/data/AdventureWorks2019Dev.mdf && touch /var/opt/mssql/data/AdventureWorks2019Dev_log.ldf"
    ```

2. **Assign Permissions**:

    Grant permissions for these files:

    ```bash
    docker exec -it your_sql_container_name bash -c "chmod 777 /var/opt/mssql/data/AdventureWorks2019Dev.mdf"
    docker exec -it your_sql_container_name bash -c "chmod 777 /var/opt/mssql/data/AdventureWorks2019Dev_log.ldf"
    ```

3. **Restore the Dev Version**:

    Either through your SQL client or `sqlcmd`, execute:

    ```sql
    USE [master]
    RESTORE DATABASE [AdventureWorks2019Dev] FROM  DISK = N'/var/opt/mssql/data/AdventureWorks2019.bak' 
    WITH  FILE = 1,  
    MOVE N'AdventureWorks2019' TO N'/var/opt/mssql/data/AdventureWorks2019Dev.mdf',  
    MOVE N'AdventureWorks2019_log' TO N'/var/opt/mssql/data/AdventureWorks2019Dev_log.ldf',  
    NOUNLOAD,  REPLACE,  STATS = 5;
    GO
    ```

> **Tip**: When wanting to restore another `.bak` file or when uncertain of the logical names inside the backup, use the Restore Database feature in SSMS. This is an option for generating the restoration script instead of executing it directly to be certain of the names.
