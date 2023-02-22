using MC.Weather.Core;
using System;

namespace MC.Weather.Cli;

internal class Program
{
    static void Main(string[] args)
    {
        var report = WeatherReport.GetReport().Result;
        Console.WriteLine("Report:");
        Console.WriteLine(report);
        Console.ReadLine();
    }
}