namespace BashSoft
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            string path = @"C:\SoftUni\C# Fundamentals\Advanced C# - May-2016\Labs\StoryMode";
            IOManager.TraverseDirectory(path);
        }
    }
}