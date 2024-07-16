namespace SignatureCommon
{
    public class Enums
    {
        public enum ExecutionResult
        {
            OK = 1,
            KO = 2,
            ERROR = 3,
            NOTVALID = 4,
            EXCEPTION = 5,
        }

        public enum Gender
        {
            Male = 0,
            Female = 1,
            _ = 2,
        }

        public enum UserStatus
        {
            New = 0,
            Active = 1,
            Inactive = 2,
        }


        public enum UserRole
        {
            Admin = 0,
            OrganizationAdmin = 1,
            OrganizationManager = 2,
            User
        }
        public enum FileStatus
        {
            New = 0,
            Signed = 1,
            Unsigned = 2,
            Inactive = 3
        }

        public enum OrganizationStatus
        {
            New = 0,
            Active = 1,
            Inactive = 2
        }
    }
}
