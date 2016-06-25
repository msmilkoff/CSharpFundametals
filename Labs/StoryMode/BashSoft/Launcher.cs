namespace BashSoft
{
    using IO;
    using Judge;
    using Network;
    using Repository;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            var tester = new Tester();
            var downloadManager = new DownloadManager();
            var ioManager = new IOManager();
            var repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            var interpreter = new CommandInterpreter(tester, repo, downloadManager, ioManager);
            var inputReader = new InputReader(interpreter);
            inputReader.StartReadingCommands();
        }
    }
}