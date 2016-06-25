namespace _09.CatLady
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var cats = new List<Cat>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var catInfo = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                switch (catInfo[0])
                {
                    case "StreetExtraordinaire":
                        cats.Add(new StreetExtraordinaire(catInfo[1], int.Parse(catInfo[2])));
                        break;
                    case "Siamese":
                        cats.Add(new Siamese(catInfo[1], int.Parse(catInfo[2])));
                        break;
                    case "Cymric":
                        cats.Add(new Cymric(catInfo[1], double.Parse(catInfo[2])));
                        break;
                }
            }

            var catName = Console.ReadLine();
            var catToPrint = cats.First(c => c.Name == catName);

            Console.WriteLine(catToPrint);
        }
    }
}
