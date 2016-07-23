namespace _0105.Cards
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            
            if (input == "Rank")
            {
                var attr = typeof(CardRank).GetCustomAttributes(false);
                Console.WriteLine(string.Join("", attr));
            }
            else
            {
                var attr = typeof(CardSuit).GetCustomAttributes(false);
                Console.WriteLine(string.Join("", attr));
            }
        }
    }

    public class Card : IComparable<Card>
    {
        public Card(CardRank rank, CardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public CardRank Rank { get; set; }

        public CardSuit Suit { get; set; }

        public int GetPower()
        {
            return (int)this.Rank + (int)this.Suit;
        }

        public int CompareTo(Card other)
        {
            return this.GetPower().CompareTo(other.GetPower());
        }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.GetPower()}";
        }
    }

    [Type("Enumeration", "Rank", "Provides suit constants for a Card class.")]
    public enum CardRank
    {
        Ace = 14,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    [Type("Enumeration", "Suit", "Provides rank constants for a Card class")]
    public enum CardSuit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }

    public class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }

        public string Type { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Type = Enumeration, Description = Provides {this.Category.ToLower()} constants for a Card class.";
        }
    }
}
