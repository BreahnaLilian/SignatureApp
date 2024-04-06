namespace SignatureDomain.Common
{
    public class Enums
    {
        public enum Status
        {
            Active = 1,
            Inactive = 2,
        }

        public enum UserStatus
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3
        }

        public enum FileStatus
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3,
            Signed = 4,
            NotSigned = 5
        }

        public enum Gender
        {
            Female = 1,
            Male = 2,
            Ohter = 3
        }
    }
}
