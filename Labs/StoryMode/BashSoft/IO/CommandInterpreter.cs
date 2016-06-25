namespace BashSoft.IO
{
    using System;
    using System.Diagnostics;
    using Judge;
    using Network;
    using Repository;
    using Static_Data;
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
            string command = data[0];
            switch (command)
            {
                case "open":
                    this.TryOpenFile(data);
                    break;
                case "mkdir":
                    this.TryCreateDirectory(data);
                    break;
                case "ls":
                    this.TryTraverseFolder(data);
                    break;
                case "cmp":
                    this.TryCompareFiles(data);
                    break;
                case "cdRel":
                    this.TryChangePathRelatively(data);
                    break;
                case "cdAbs":
                    this.TryChangePathAbsolute(data);
                    break;
                case "readDb":
                    this.TryReadDataFromFile(data);
                    break;
                case "help":
                    this.TryGetHelp(data);
                    break;
                case "show":
                    this.TryShowWantedData(input, data);
                    break;
                case "filter":
                    this.TryFilterAndTake(input, data);
                    break;
                case "order":
                    this.TryOrderAndTake(input, data);
                    break;
                case "decOrder":
                    // TODO:
                    break;
                case "download":
                    this.TryDownloadFile(input, data);
                    break;
                case "downloadAsynch":
                    this.TryDownloadFileAsync(input, data);
                    break;
                case "dropDb":
                    this.TryDropDb(input, data);
                    break;
                default:
                    this.DisplayInvalidCommanndMessage(command);
                    break;
            }
        }

        private void TryDropDb(string input, string[] data)
        {
            if (data.Length != 1)
            {
                this.DisplayInvalidCommanndMessage(input);
                return;
            }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }

        private void TryDownloadFileAsync(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                this.downloadManager.DownloadAsync(url);
            }
            else
            {
                this.DisplayInvalidCommanndMessage(input);
            }
        }

        private void TryDownloadFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                this.downloadManager.Download(url);
            }
            else
            {
                this.DisplayInvalidCommanndMessage(input);
            }
        }

        private void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string comparison = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                this.TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
            }
        }

        private void TryParseParametersForOrderAndTake(
            string takeCommand,
            string takeQuantity,
            string courseName,
            string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.repository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                this.TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
        }

        private void TryParseParametersForFilterAndTake(
            string takeCommand,
            string takeQuantity,
            string courseName,
            string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentToTake);
                    if (hasParsed)
                    {
                        this.repository.FilterAndTake(courseName, filter, studentToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string userName = data[2];
                this.repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                this.DisplayInvalidCommanndMessage(input);
            }
        }

        private void TryGetHelp(string[] data)
        {
            this.CheckParams(data, 1);

            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private void TryReadDataFromFile(string[] data)
        {
            this.CheckParams(data, 2);

            string fileName = data[1];
            this.repository.LoadData(fileName);
        }

        private void TryChangePathAbsolute(string[] data)
        {
            this.CheckParams(data, 2);

            string absolutePath = data[1];
            this.ioManager.ChangeCurentDirectoryAbsolute(absolutePath);
        }

        private void TryChangePathRelatively(string[] data)
        {
            this.CheckParams(data, 2);

            string relPath = data[1];
            this.ioManager.ChangeCurrentDirectoryRelative(relPath);
        }

        private void TryCompareFiles(string[] data)
        {
            this.CheckParams(data, 3);

            string firstPath = data[1];
            string secondPath = data[2];

            this.judge.CompareContent(firstPath, secondPath);
        }

        private void TryTraverseFolder(string[] data)
        {
            if (data.Length == 1)
            {
                this.ioManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);
                if (hasParsed)
                {
                    this.ioManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
            }
        }

        private void TryCreateDirectory(string[] data)
        {
            this.CheckParams(data, 2);

            string folderName = data[1];
            this.ioManager.CreateDirectoryInCurretFolder(folderName);
        }

        private void TryOpenFile(string[] data)
        {
            this.CheckParams(data, 2);

            string fileName = data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }

        private void DisplayInvalidCommanndMessage(string command)
        {
            OutputWriter.DisplayException(string.Format(ExceptionMessages.InvalidCommand, command));
        }

        private void CheckParams(string[] data, int length)
        {
            if (data.Length != length)
            {
                OutputWriter.DisplayException($"Invalid number of parameters for the {data[0]} command.");
            }
        }
    }
}