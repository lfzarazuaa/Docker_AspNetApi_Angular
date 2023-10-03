namespace WebApiMdm.Utils.Extensions;

/// <summary>
/// Contains extension methods for DateTime objects.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Checks if the provided date falls on a weekend.
    /// </summary>
    /// <returns>True if the date is a weekend; otherwise, false.</returns>
    public static bool IsWeekend(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }

    /// <summary>
    /// Calculates age based on the provided birthdate.
    /// </summary>
    /// <returns>Age in years.</returns>
    public static int CalculateAge(this DateTime birthDate)
    {
        int age = DateTime.Now.Year - birthDate.Year;
        if (DateTime.Now.Date < birthDate.AddYears(age)) age--;
        return age;
    }
}


