namespace _11.Rectangedoubleersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Drawing;

    public class StartUp
    {
        public static void Main()
        {
            var loopParams = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double numberOfRectangles = loopParams[0];
            double doubleersectionChecks = loopParams[1];

            var rectangles = new Dictionary<string, Rectangle>();
            for (double i = 0; i < numberOfRectangles; i++)
            {
                var rectInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string id = rectInfo[0];
                double width = double.Parse(rectInfo[1]);
                double hight = double.Parse(rectInfo[2]);
                double x = double.Parse(rectInfo[3]);
                double y = double.Parse(rectInfo[4]);

                var coord = new Coord(x, y);
                if (!rectangles.ContainsKey(id))
                {
                    rectangles.Add(id, new Rectangle((int)x, (int)y, (int)width, (int)hight));
                }
            }

            for (double i = 0; i < doubleersectionChecks; i++)
            {
                var rectIds = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                bool result = rectangles[rectIds[0]].IntersectsWith(rectangles[rectIds[1]]);
                Console.WriteLine(result.ToString().ToLower());
            }
        }
    }
    
    public struct Coord
    {
        public Coord(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}
