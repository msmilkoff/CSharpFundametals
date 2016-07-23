namespace _07.DeckOfCards
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            // Extremely lazy solution...

            string[] cards = {
                "Ace",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Jack",
                "Queen",
                "King"
            };

            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine($"{cards[i]} of Clubs");
            }

            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine($"{cards[i]} of Hearts");
            }

            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine($"{cards[i]} of Diamonds");
            }

            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine($"{cards[i]} of Spades");
            }
        }
    }
}
