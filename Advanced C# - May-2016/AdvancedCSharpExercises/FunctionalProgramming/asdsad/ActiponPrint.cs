namespace _01.ActionPrint
{
    using System;
    using System.Linq;

    public class ActiponPrint
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();

            Action<string[]> action = strings => Console.WriteLine(string.Join("\n", strings));
            action(input);
        }
    }
}