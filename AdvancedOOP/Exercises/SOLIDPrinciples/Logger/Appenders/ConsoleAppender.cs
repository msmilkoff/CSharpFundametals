namespace SimpleLogger.Appenders
{
    using System;
    using Contracts;

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel level, string message)
        {
            if (level < this.ReportLevel)
            {
                return;
            }

            string format = layout.Format;
            string result = string.Format(format, dateTime, level, message);

            Console.WriteLine(result);
        }
    }
}