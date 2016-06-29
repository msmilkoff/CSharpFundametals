namespace _08.ShapesVolume
{
    using System;
    using System.Linq;

    public class ShapesVolume
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] shapeInfo = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string shapeName = shapeInfo[0];
                double[] shapeParams = shapeInfo.Skip(1).Select(double.Parse).ToArray();

                switch (shapeName)
                {
                    case "TrianglePrism":
                        var prism = new TriangularPrism(shapeParams[0], shapeParams[1], shapeParams[2]);
                        var prismVolume = VolumeCalculator.CalculateTriangularPrismVolume(prism);
                        Console.WriteLine($"{prismVolume:F3}");
                        break;
                    case "Cube":
                        var cube = new Cube(shapeParams[0]);
                        var cubeVolume = VolumeCalculator.CalculateCubeVolume(cube);
                        Console.WriteLine($"{cubeVolume:F3}");
                        break;
                    case "Cylinder":
                        var cylinder = new Cylinder(shapeParams[0], shapeParams[1]);
                        var cylinderVolume = VolumeCalculator.CalculateCylinderVolume(cylinder);
                        Console.WriteLine($"{cylinderVolume:F3}");
                        break;
                }
                
                input = Console.ReadLine();
            }
        }
    }

    public static class VolumeCalculator
    {
        public static double CalculateTriangularPrismVolume(TriangularPrism prism)
        {
            double result = (prism.BaseSide * prism.Hight * prism.Length) / 2;
            return result;
        }

        public static double CalculateCubeVolume(Cube cube)
        {
            double result = Math.Pow(cube.SideLength, 3);
            return result;
        }

        public static double CalculateCylinderVolume(Cylinder cylinder)
        {
            double result = Math.PI * Math.Pow(cylinder.Radius, 2) * cylinder.Hight;
            return result;
        }
    }

    public class TriangularPrism
    {
        public TriangularPrism(double baseSide, double hight, double length)
        {
            this.BaseSide = baseSide;
            this.Hight = hight;
            this.Length = length;
        }

        public double BaseSide { get; }

        public double Hight { get; }

        public double Length { get; }
    }

    public class Cube
    {
        public Cube(double sideLength)
        {
            this.SideLength = sideLength;
        }

        public double SideLength { get; }
    }

    public class Cylinder
    {
        public Cylinder(double radius, double hight)
        {
            this.Radius = radius;
            this.Hight = hight;
        }

        public double Radius { get; }

        public double Hight { get; }
    }
}
