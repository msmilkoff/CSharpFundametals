namespace _13.DrawingTool
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var shapeType = Console.ReadLine();

            var drawer = new CorDraw();
            if (shapeType == "Rectangle")
            {
                int width = int.Parse(Console.ReadLine());
                int hight = int.Parse(Console.ReadLine());

                var rectangle = new Rectangle(width, hight);
                drawer.Draw(rectangle);
            }
            else if (shapeType == "Square")
            {
                int width = int.Parse(Console.ReadLine());

                var square = new Square(width);
                drawer.Draw(square);
            }
        }
    }

    public class CorDraw
    {
        public void Draw(Shape shape)
        {
            shape.Draw();
        }
    }

    public class Square : Shape
    {
        public Square(int width)
            : base(width, width)
        {
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(int width, int heigth)
            : base(width, heigth)
        {
        }
    }

    public abstract class Shape
    {
        protected Shape(int width, int heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public int Width { get; set; }

        public int Heigth { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine($"|{new string('-', this.Width)}|");
            for (int i = 0; i < this.Heigth - 2; i++)
            {
                Console.WriteLine($"|{new string(' ', this.Width)}|");
            }

            Console.WriteLine($"|{new string('-', this.Width)}|");
        }
    }
}
