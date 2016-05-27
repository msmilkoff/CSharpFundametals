namespace BashSoft
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IOManager.ChangeCurentDirectoryAbsolute(@"C:\Windows");
            IOManager.TraverseDirectory(20);
        }
    }
}