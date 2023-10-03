using System;
using System.Diagnostics.Metrics;
using System.IO;
using WebApiMdm.Utils.Extensions;

namespace WebApiMdm.DataAccess.Connection;

public static class ConnectionHelper
{
    private static readonly string SolutionDirectory = AppContext.BaseDirectory.Split(new[] { @"bin\" }, StringSplitOptions.None)[0];
    private static readonly string EnvFilePathAtProjectLevel = Path.Combine(SolutionDirectory, "..", "..", ".env");

    public static IConfiguration? configuration;

    public static string GetConnectionString(string dbNameKey)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException("No configuration provided by Builder.");
        }

        string? password = Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD");
        string? environment = Environment.GetEnvironmentVariable("API_ENV_MODE");

        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(environment))
        {
            // Only read the .env file if necessary.
            var envValues = ReadEnvValues();

            password = password ?? envValues["MSSQL_SA_PASSWORD"];
            environment = environment ?? envValues["API_ENV_MODE"];
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("MSSQL_SA_PASSWORD not defined.");
        }

        string baseConnection = configuration["CustomizedConnectionStrings:BaseConnection"];
        string serverName = configuration[$"CustomizedConnectionStrings:Environments:{environment}:ServerName"];
        string userName = configuration[$"CustomizedConnectionStrings:Environments:{environment}:UserName"];
        string dbName = dbNameKey == "master" ? dbNameKey : configuration[$"CustomizedConnectionStrings:Environments:{environment}:DbNames:{dbNameKey}"];

        environment = "Default";
        serverName= serverName.DefaultIfNullOrEmpty(configuration[$"CustomizedConnectionStrings:Environments:{environment}:ServerName"]);
        userName = userName.DefaultIfNullOrEmpty(configuration[$"CustomizedConnectionStrings:Environments:{environment}:UserName"]);
        dbName = dbName.DefaultIfNullOrEmpty(configuration[$"CustomizedConnectionStrings:Environments:{environment}:DbNames:{dbNameKey}"]);
        
        var connectionString = baseConnection
            .Replace("{ServerName}", serverName)
            .Replace("{UserName}", userName)
            .Replace("{DbName}", dbName)
            .Replace("{MSSQL_SA_PASSWORD}", password);
        return connectionString;
    }

    private static string GetEnvValueOrFallback(string key, Dictionary<string, string> envValues)
    {
        return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(key))
               ? (Environment.GetEnvironmentVariable(key) ?? string.Empty)
               : envValues[key];
    }


    private static Dictionary<string, string> ReadEnvValues()
    {
        var values = new Dictionary<string, string>();

        if (!File.Exists(EnvFilePathAtProjectLevel))
        {
            throw new FileNotFoundException(".env file not found.");
        }

        var lines = File.ReadAllLines(EnvFilePathAtProjectLevel);
        foreach (var line in lines)
        {
            // Removing comments (everything after # including the symbol and spaces)
            var cleanLine = line.Split('#')[0].Trim();

            if (cleanLine.StartsWith("MSSQL_SA_PASSWORD="))
            {
                values["MSSQL_SA_PASSWORD"] = cleanLine.Split('=')[1]?.Trim() ?? string.Empty;
            }
            else if (cleanLine.StartsWith("API_ENV_MODE="))
            {
                values["API_ENV_MODE"] = cleanLine.Split('=')[1]?.Trim() ?? string.Empty;
            }
        }

        return values;
    }

}


