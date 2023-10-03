using System.Text.RegularExpressions;
using WebApiMdm.DataAccess.Services.Interfaces;

namespace WebApiMdm.DataAccess.Services;

public abstract class SqlQueryService: ISqlQueryService
{
    private readonly string _basePath;

    public SqlQueryService(string basePath)
    {
        _basePath = basePath;
    }

    public Dictionary<string, string> ParseSqlFile(params string[] path)
    {
        var fullPath = Path.Combine(_basePath, Path.Combine( path) );
        var fileContent = File.ReadAllText(fullPath);

        var queries = new Dictionary<string, string>();

        var matches = Regex.Matches(fileContent, @"--\s*#####\s*Begin Query: (\w+)\s*#####\s*(.*?)--\s*#####\s*End Query\s*#####", RegexOptions.Singleline);

        foreach (Match match in matches)
        {
            var queryName = match.Groups[1].Value;
            var queryContent = match.Groups[2].Value.Trim();

            if (queries.ContainsKey(queryName))
            {
                throw new Exception($"Duplicate query name detected: {queryName}");
            }

            queries.Add(queryName, queryContent);
        }

        return queries;
    }
}

