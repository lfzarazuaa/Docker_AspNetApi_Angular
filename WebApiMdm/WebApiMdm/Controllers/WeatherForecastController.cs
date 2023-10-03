using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using WebApiMdm.Models.DbModels.AdventureWorks2019;
using WebApiMdm.Models.Dtos.Response.AdventureWorks2019;
using WebApiMdm.DataAccess.Connection;

namespace WebApiMdm.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly string _connectionString = ConnectionHelper.GetConnectionString("master");

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [HttpGet("Summary")]
    public IEnumerable<WeatherForecast> GetWeatherForecastSummary()
    {
        return Enumerable.Range(1, 15).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("ByPlace")]
    public ActionResult<IEnumerable<object>> GetWeatherByPlace()
    {
        var random = new Random();

        // Generate a random number of objects between 10 and 30
        int numberOfObjects = random.Next(10, 31);

        var dataList = new List<object>();

        for (int i = 0; i < numberOfObjects; i++)
        {
            var data = new
            {
                latitude = random.NextDouble() * (90.0 - (-90.0)) + (-90.0),  // Random latitude between -90 and 90
                longitude = random.NextDouble() * (180.0 - (-180.0)) + (-180.0), // Random longitude between -180 and 180
                temperature = random.Next(-50, 51),  // Random temperature between -50°C and 50°C
                date = DateTime.Now.AddDays(random.Next(0, 31))  // Random date in the current month
            };

            dataList.Add(data);
        }

        return Ok(dataList);
    }

    [HttpGet("test-sql-connection")]
    public IActionResult TestSqlConnection()
    {
        string connectionString = ConnectionHelper.GetConnectionString("master"); ;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Example: Get the SQL Server version
                using (SqlCommand cmd = new SqlCommand("SELECT @@VERSION;", connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Ok($"SQL Server Version: {result}");
                    }
                }
            }
            catch (SqlException ex)
            {
                return BadRequest($"Error connecting to SQL Server: {ex.Message}");
            }
        }

        return BadRequest("Unknown error occurred.");
    }

    [HttpGet("GetUnitMeasures")]
    public ActionResult<IEnumerable<UnitMeasure>> GetUnitMeasures()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var unitMeasures = connection.Query<UnitMeasure>("SELECT * FROM [Production].[UnitMeasure]").AsList();
            return Ok(unitMeasures);
        }
    }

    [HttpGet("GetUnitMeasureDTOs")]
    public ActionResult<IEnumerable<UnitMeasureDTO>> GetUnitMeasureDTOs()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            var unitMeasures = connection.Query<UnitMeasure>("SELECT * FROM [Production].[UnitMeasure]").AsList();

            List<UnitMeasureDTO> unitMeasureDTOs = new List<UnitMeasureDTO>();
            foreach (var measure in unitMeasures)
            {
                unitMeasureDTOs.Add(new UnitMeasureDTO
                {
                    UnitMeasureCode = measure.UnitMeasureCode,
                    Name = measure.Name,
                    ModifiedDate = measure.ModifiedDate,
                    RandomData = Guid.NewGuid().ToString()
                });
            }
            return Ok(unitMeasureDTOs);
        }
    }
}
