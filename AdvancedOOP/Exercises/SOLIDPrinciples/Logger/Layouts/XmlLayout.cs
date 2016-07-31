namespace SimpleLogger.Layouts
{
    using Contracts;

    public class XmlLayout : ILayout
    {
        public XmlLayout()
        {
            this.Format = GetFormat();
        }

        public string Format { get; private set; }

        private string GetFormat()
        {
            string format =
@"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";

            return format;
        }
    }
}