namespace SimpleLogger.Loggers
{
    using Contracts;

    public class Logger : ILogger
    {
        private IAppender appender;

        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public void Info(string time, string message)
        {
            this.appender.Append(time, ReportLevel.Info, message);
        }

        public void Warning(string time, string message)
        {
            this.appender.Append(time, ReportLevel.Warning, message);
        }

        public void Error(string time, string message)
        {
            this.appender.Append(time, ReportLevel.Error, message);
        }

        public void Critical(string time, string message)
        {
            this.appender.Append(time, ReportLevel.Critical, message);
        }

        public void Fatal(string time, string message)
        {
            this.appender.Append(time, ReportLevel.Fatal, message);
        }
    }
}