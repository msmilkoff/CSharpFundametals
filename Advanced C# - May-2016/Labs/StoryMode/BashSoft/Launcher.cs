namespace BashSoft
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            StudentsRepository.InitializeData();
            StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
        }
    }
}