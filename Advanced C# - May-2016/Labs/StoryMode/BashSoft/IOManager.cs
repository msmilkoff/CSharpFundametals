namespace BashSoft
{
    using System.Collections.Generic;
    using System.IO;

    public static class IOManager
    {
        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;

            var subFolders = new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;
                var ident = new string('-', identation);
                OutputWriter.WriteMessageOnNewLine($"{ident}{currentPath}");

                var directories = Directory.GetDirectories(currentPath);
                foreach (var directoryPath in directories)
                {
                    subFolders.Enqueue(directoryPath);
                }
            }
        }
    }
}
