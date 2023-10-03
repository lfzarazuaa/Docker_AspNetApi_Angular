using System.ComponentModel;
using System.Diagnostics;

namespace WebApiMdm.Utils.Helpers;
/// <summary>
/// Provides utility methods useful for debugging.
/// </summary>
public static class DebugHelper
{
    /// <summary>
    /// Prints the name and value of all properties of an object.
    /// </summary>
    public static void PrintProperties(object obj)
    {
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
        {
            string name = descriptor.Name;
            object? value = descriptor.GetValue(obj);
            Console.WriteLine($"{name} = {value}");
        }
    }

    /// <summary>
    /// Measures and displays the execution time of a provided method.
    /// </summary>
    /// <param name="action">The method/action to measure.</param>
    public static void MeasureExecutionTime(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}

