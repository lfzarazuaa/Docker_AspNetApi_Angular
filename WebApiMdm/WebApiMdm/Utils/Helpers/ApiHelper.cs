using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApiMdm.Utils.Helpers;

/// <summary>
/// Provides utility methods related to API operations.
/// </summary>
public static class ApiHelper
{
    private static readonly HttpClient _httpClient = new HttpClient();

    /// <summary>
    /// Generates a standardized response for successful operations.
    /// </summary>
    /// <param name="message">Message detailing the success.</param>
    /// <param name="data">Optional data payload.</param>
    /// <returns>An IActionResult with the success details.</returns>
    public static IActionResult GenerateSuccessResponse(string message, object? data = null)
    {
        return new OkObjectResult(new
        {
            status = "success",
            message,
            data
        });
    }

    /// <summary>
    /// Generates a standardized response for errors.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>An IActionResult with the error details.</returns>
    public static IActionResult GenerateErrorResponse(string message)
    {
        return new BadRequestObjectResult(new
        {
            status = "error",
            message
        });
    }

    /// <summary>
    /// Checks if a given URL is accessible.
    /// </summary>
    /// <param name="url">The URL to check.</param>
    /// <returns>True if the URL is accessible; otherwise, false.</returns>
    public static async Task<bool> IsUrlAccessible(string url)
    {
        try
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}

