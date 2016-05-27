﻿namespace BashSoft
{
    public static class ExceptionMessages
    {
        public const string DataAlreadyInitialisedMessage = "Data is already initialized!";

        public const string DataNotInitializedMessage =
            "The data structure must be initialised first in order to make any operations with it.";

        public const string InexistingCourseInDataBase =
            "The course you are trying to get does not exist in the data base!";

        public const string InexistingStudentInDataBase =
            "The user name for the student you are trying to get does not exist!";

        public const string InvalidPath =
            "The folder/file you are trying to access at the current address, does not exist.";

        public const string UnauthorizedAccessExceptionMessage =
            "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string ForbiddenSymbolsContainedInName =
            "The given name contains symbols that are not allowed to be used in names of files and folders.";
    }
}
