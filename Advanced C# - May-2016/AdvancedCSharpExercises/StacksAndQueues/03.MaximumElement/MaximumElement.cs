using System;

namespace _03.MaximumElement
{
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main(string[] args)
        {
            int queriesCount = int.Parse(Console.ReadLine());

            var elements = new Stack<int>();
            var maxValues = new Stack<int>();

            int maxElement = int.MinValue;

            for (int i = 0; i < queriesCount; i++)
            {
                string querie = Console.ReadLine();
                switch (querie)
                {
                    case "2":
                        int topElement = elements.Pop();
                        int currentMax = maxValues.Peek();
                        if (topElement == currentMax)
                        {
                            maxValues.Pop();
                            maxElement = maxValues.Count > 0 ? maxValues.Peek() : int.MinValue;
                        }

                        break;
                    case "3":
                        Console.WriteLine(maxValues.Peek());
                        break;
                    default:
                        var element = int.Parse(querie.Substring(2));
                        elements.Push(element);
                        if (element >= maxElement)
                        {
                            maxElement = element;
                            maxValues.Push(maxElement);
                        }

                        break;
                }
            }
        }
    }
}