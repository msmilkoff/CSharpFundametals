namespace BashSoft
{
    using SimpleJudge;
    using System.Collections.Generic;
    using System.IO;
    using System;

    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;

            var subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;
                if (depth - identation < 0)
                {
                    break;
                }

                var ident = new string('-', identation);
                OutputWriter.WriteMessageOnNewLine($"{ident}{currentPath}");

                foreach (var file in Directory.GetFiles(currentPath))
                {
                    int indexOfLastSlash = file.LastIndexOf('\\');
                    string fileName = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                }

                var directories = Directory.GetDirectories(currentPath);
                foreach (var directoryPath in directories)
                {
                    subFolders.Enqueue(directoryPath);
                }
            }
        }

        public static void CreateDirectoryInCurretFolder(string name)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + name;
            Directory.CreateDirectory(path);
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                int indexOfLastSlash = currentPath.LastIndexOf('\\');
                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurentDirectoryAbsolute(currentPath);
            }
        }

        private static void ChangeCurentDirectoryAbsolute(string absolutePath)
        {
            if (Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            SessionData.currentPath = absolutePath;
        }
    }
}
