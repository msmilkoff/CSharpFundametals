namespace _02.BookShop
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book);
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, double price)
            :base(author, title, price)
        {
        }

        public override double Price => base.Price * 1.3;
    }

    public class Book
    {
        private string title;
        private string author;
        private double price;

        public Book(string author, string title, double price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual string Title
        {
            get { return this.title; }
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public virtual string Author
        {
            get { return this.author; }
            protected set
            {
                string[] names = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (names.Length == 1)
                {
                    this.author = value;
                }
                else if (names.Length == 2)
                {
                    if (char.IsDigit(names[1][0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }

                    this.author = value;
                }
            }
        }

        public virtual double Price
        {
            get { return this.price; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type: ").Append(this.GetType().Name)
                    .Append(Environment.NewLine)
                    .Append("Title: ").Append(this.Title)
                    .Append(Environment.NewLine)
                    .Append("Author: ").Append(this.Author)
                    .Append(Environment.NewLine)
                    .Append("Price: ").Append($"{this.Price:F1}")
                    .Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}

