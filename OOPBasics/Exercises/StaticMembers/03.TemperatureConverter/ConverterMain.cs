namespace _03.TemperatureConverter
{
    using System;

    public class ConverterMain
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                var degreesInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int degrees = int.Parse(degreesInfo[0]);
                string unit = degreesInfo[1];

                double result;
                if (unit == "Fahrenheit")
                {
                    result = TemperatureCoverter.ConvertToCelsisus(degrees);
                    Console.WriteLine($"{result:F2} Celsius");
                }
                else if (unit == "Celsius")
                {
                    result = TemperatureCoverter.ConvertToFahrenheit(degrees);
                    Console.WriteLine($"{result:F2} Fahrenheit");
                }

                input = Console.ReadLine();
            }
        }
    }

    public static class TemperatureCoverter
    {
        public static double ConvertToCelsisus(int fahrenheitDegrees)
        {
            double result = ((double)fahrenheitDegrees - 32) / 1.8;

            return result;
        }

        public static double ConvertToFahrenheit(int celsiusDegrees)
        {
            double result = celsiusDegrees * 1.8 + 32;

            return result;
        }
    }
}
