namespace BashSoft.Exceptions
{
    using System;

    public class DuplicateEntryInStructureException : Exception
    {
        public const string StudentAlreadyEnrolled = "TheThe {0} already exists in {1}.";

        public DuplicateEntryInStructureException(string entry, string structure)
            :base(string.Format(StudentAlreadyEnrolled, entry, structure))
        { 
        }

        public DuplicateEntryInStructureException(string message)
            :base(message)
        {
        }
    }
}