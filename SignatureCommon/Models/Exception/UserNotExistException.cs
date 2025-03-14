namespace SignatureCommon.Models.Exception;

public class UserNotExistException : System.Exception
{
    public UserNotExistException()
    {
    }

    public UserNotExistException(string email) : base("User with email \" " + email + " \" not exist.")
    {
    }

    public UserNotExistException(string email, System.Exception inner) : base("User with email \" " + email + " \" not exist.", inner)
    {
    }
}