namespace BashSoft
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IOManager.CreateDirectoryInCurretFolder("pesho");
            IOManager.TraverseDirectory(0);
        }
    }
}