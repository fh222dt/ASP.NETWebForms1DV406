using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TemperatureConverter
/// </summary>
public static class TemperatureConverter
{
	public static int CelsiusToFahrenheit (int degreesC)
    {
        int fahrenheit = 0;

        fahrenheit = (degreesC * 9 / 5) + 32;

        return fahrenheit;
    }

    public static int FahrenheitToCelsius (int degreesF)
    {
        int celsius = 0;

        celsius = (degreesF - 32) * 5 / 9;

        return celsius;
    }
    
}