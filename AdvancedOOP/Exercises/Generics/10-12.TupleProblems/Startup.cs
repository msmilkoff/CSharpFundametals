namespace _10_12.TupleProblems
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] first = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] second = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] third = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var firstTuple = new CustomTuple<string, string, string>();
            firstTuple.Item1 = first[0] + " " + first[1];
            firstTuple.Item2 = first[2];
            firstTuple.Item3 = first[3];

            var secondTuple = new CustomTuple<string, string, string>
            {
                Item1 = second[0],
                Item2 = second[1],
                Item3 = second[2]
            };

            var thirdTuple = new CustomTuple<string, double, string>
            {
                Item1 = third[0],
                Item2 = double.Parse(third[1]),
                Item3 = third[2]
            };

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2} -> {firstTuple.Item3}");
            Console.WriteLine(secondTuple.Item3 == "drunk" 
                ? $"{secondTuple.Item1} -> {secondTuple.Item2} -> True"
                : $"{secondTuple.Item1} -> {secondTuple.Item2} -> False");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2:F1} -> {thirdTuple.Item3}");
        }
    }

    public class CustomTuple<T, U, V>
    {
        public T Item1 { get; set; }

        public U Item2 { get; set; }

        public V Item3 { get; set; }
    }
}
