namespace _06.Animals
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                try
                {
                    ParseInput(input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }

                input = Console.ReadLine();
            }
        }

        private static void ParseInput(string input)
        {
            string[] tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (input)
            {
                case "Cat":
                    var cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                    break;
                case "Dog":
                    var dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                    break;
                case "Frog":
                    var frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                    break;
                case "Kitten":
                    var kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                    break;
                case "Tomcat":
                    var tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                    break;
                default:
                    Console.WriteLine("Not implemented!");
                    break;
            }
        }
    }

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age)
        {
            this.Gender = "Male";
        }

        public override string ToString()
        {
            return $"Tomcat {this.Name} {this.Age} {this.Gender}";
        }

        public override string ProduceSound()
        {
            return $"Give me one million b***h";
        }
    }

    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age)
        {
            this.Gender = "Female";
        }

        public override string ToString()
        {
            return $"Kitten {this.Name} {this.Age} {this.Gender}";
        }

        public override string ProduceSound()
        {
            return $"Miau";
        }
    }

    public class Frog : Animal
    {
        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string ToString()
        {
            return $"Frog {this.Name} {this.Age} {this.Gender}";
        }

        public override string ProduceSound()
        {
            return $"Frogggg";
        }
    }

    public class Cat : Animal
    {
        public Cat(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public Cat(string name, int age)
            :base(name, age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Cat {this.Name} {this.Age} {this.Gender}";
        }

        public override string ProduceSound()
        {
            return $"MiauMiau";
        }
    }

    public class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string ToString()
        {
            return $"Dog {this.Name} {this.Age} {this.Gender}";
        }

        public override string ProduceSound()
        {
            return $"BauBau";
        }
    }

    public class Animal : ISoundProducible
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public override string ToString()
        {
            return $"Animal {this.Name} {this.Age} {this.Gender}";
        }

        public virtual string ProduceSound()
        {
            return $"Not implemented!";
        }
    }

    public interface ISoundProducible
    {
        string ProduceSound();
    }
}
