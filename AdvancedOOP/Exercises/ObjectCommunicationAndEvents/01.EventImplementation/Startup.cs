namespace _01.EventImplementation
{
    using System;

    public class Startup
    {
        static void Main()
        {
            var disp = new Dispatcher();

            string input = Console.ReadLine();
            while (input != "End")
            {
                disp.Name = input;

                input = Console.ReadLine();
            }
        }
    }

    public class Dispatcher
    {
        public event NameChangedEventHandler NameChanged;
        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.OnNameChanged(value);
            }
        }

        protected virtual void OnNameChanged(string name)
        {
            if (this.NameChanged != null)
            {
                this.NameChanged();
            }
            else
            {
                Console.WriteLine($"Dispatcher's name changed to {name}.");
            }
        }
    }

    public delegate void NameChangedEventHandler();
}
