namespace WebApiMdm.Utils.Extensions;
/// <summary>
/// Contains extension methods for string objects.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Checks if a string is null or empty.
    /// </summary>
    /// <returns>True if the string is null or empty; otherwise, false.</returns>
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// Truncates a string if it exceeds a specified length.
    /// </summary>
    /// <param name="maxLength">The maximum number of characters the string can have.</param>
    /// <returns>A truncated string or the original string if its length is less than or equal to maxLength.</returns>
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }

    /// <summary>
    /// Returns the original string if it's not null or empty; otherwise, returns the provided default value.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="defaultValue">The default value to return if the string is null or empty.</param>
    /// <returns>The original string if it's not null or empty; otherwise, the default value.</returns>
    public static string DefaultIfNullOrEmpty(this string value, string defaultValue)
    {
        return string.IsNullOrEmpty(value) ? defaultValue : value;
    }

    /// <summary>
    /// Converts a string to title case.
    /// </summary>
    /// <returns>A string with each word's first letter in uppercase.</returns>
    public static string ToTitleCase(this string value)
    {
        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
    }
}
