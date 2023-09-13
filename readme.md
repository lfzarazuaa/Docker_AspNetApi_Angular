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

For the development mode, follow these steps:

1. Download the source code.
2. Build all the images (required when adding new packages or changing the order in the Dockerfile).

   ```bash
   docker-compose build --no-cache
    ```

3. Run all the containers.

    ```bash
    >> docker-compose up
    ```

4. Connect using Visual Studio Code's Remote Container feature.

5. Stop the services via the Docker UI or execute the following command:

    ```bash
    >> docker-compose down
    ```

For the ``production mode``, which is a lightweight version without dev tools:

1. Download the source code.
2. Build all the images (necessary when adding new packages or if the Dockerfile order changes).

    ```bash
    >> docker-compose -f docker-compose.prod.yml build --no-cache
    ```

3. Run all the containers.

    ```bash
    >> docker-compose -f docker-compose.prod.yml up
    ```

4. Connect using Visual Studio Code's Remote Container feature.

5. Stop the services via the Docker UI or use the command:

    ```bash
    >> docker-compose down
    ```
