namespace SimpleLogger.Layouts
{
    using Contracts;

    public class SimpleLayout : ILayout
    {
        private const string SimpleFormat = "{0} -- {1} -- {2}";

        public SimpleLayout()
        {
            this.Format = SimpleFormat;
        }

        public string Format { get; private set; }
    }
}