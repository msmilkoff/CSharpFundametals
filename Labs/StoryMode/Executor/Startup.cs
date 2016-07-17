namespace Executor
{
    using IO;
    using Judge;
    using Network;
    using Repository;
    
    public class Startup
    {
        public static void Main()
        {                  
            var tester = new Tester();
            var downloadManager = new DownloadManager();
            var ioManager = new IOManager();
            var repo = new StudentsRepository(new RepositorySorter(), new RepositioryFilter());

            var currentInterpreter = new CommandInterpreter(tester, repo, downloadManager, ioManager);
            var reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}