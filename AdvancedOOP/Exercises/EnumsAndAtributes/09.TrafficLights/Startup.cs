namespace _09.TrafficLights
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] lights = Console.ReadLine().Split();
            int changeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < changeCount; i++)
            {
                string[] currentLights = ChangeColors(lights);

                Console.WriteLine(string.Join(" ", currentLights));
                lights = currentLights;
            }
        }

        public static string[] ChangeColors(string[] arr)
        {
            if (arr[2].ToUpper() == "RED")
            {
                return new[] { "Red", "Yellow", "Green" };
            }
            else if (arr[2].ToUpper() == "YELLOW")
            {
                return new[] { "Yellow", "Green", "Red" };
            }
            else if (arr[2].ToUpper() == "GREEN")
            {
                return new[] { "Green", "Red", "Yellow" };
            }

            return null;
        }
    }
}
