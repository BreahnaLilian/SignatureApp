namespace SignatureCommon.Models.Exception;

public class UserAlreadyExistException : System.Exception
{
    public UserAlreadyExistException()
    {
    }

    public UserAlreadyExistException(string email) : base("User with email \" " + email + " \" already exist.")
    {
    }

    public UserAlreadyExistException(string email, System.Exception inner) : base("User with email \" " + email + " \" already exist.", inner)
    {
    }
}