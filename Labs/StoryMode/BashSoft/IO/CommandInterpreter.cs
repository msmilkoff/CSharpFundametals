namespace BashSoft.IO
{
    using System;
    using System.Diagnostics;
    using Judge;
    using Network;
    using Repository;
    using Static_Data;
    using Commands;
    using Exceptions;

    public class CommandInterpreter
    {
        private Tester judge;
        private StudentsRepository repository;
        private DownloadManager downloadManager;
        private IOManager ioManager;

        public CommandInterpreter(
            Tester judge,
            StudentsRepository repository,
            DownloadManager downloadManager,
            IOManager ioManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.ioManager = ioManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0];
            commandName = commandName.ToLower();

            try
            {
                var command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private Command ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "cmp":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager); ;
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "decorder":
                    // TODO:
                    break;
                case "download":
                    return new DownloadFileCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "downloadasynch":
                    return new DownloadAsynchCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.downloadManager, this.ioManager);
            }

            throw new InvalidCommandException();
        }
    }
}