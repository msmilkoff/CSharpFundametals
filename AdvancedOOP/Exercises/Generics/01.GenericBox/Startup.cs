namespace _01_07.GenericBox
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var list = new List<double>();

            int linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                double token = double.Parse(Console.ReadLine());
                list.Add(token);
            }

            double target = double.Parse(Console.ReadLine());

            int result = GetGreaterThanCount(list, target);

            Console.WriteLine(result);
        }

        private static int GetGreaterThanCount<T>(List<T> list, T element)
            where T : IComparable
        {
            int count = 0;
            foreach (T item in list)
            {
                if (item.CompareTo(element) == 1)
                {
                    count++;
                }
            }

            return count;
        }
    }

    public class Box<T> : IComparable
        where T : IComparable
    {
        public T Value { get; set; }

        public int CompareTo(object obj)
        {
            return this.Value.CompareTo(obj);
        }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}