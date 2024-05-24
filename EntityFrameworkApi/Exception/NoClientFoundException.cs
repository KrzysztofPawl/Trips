namespace EntityFrameworkApi.Exception;

public class NoClientFoundException : System.Exception
{
    public NoClientFoundException() : base("No Client found")
    {
    }

    public NoClientFoundException(string message) : base(message)
    {
    }

    public NoClientFoundException(string message, System.Exception inner) : base(message, inner)
    {
    }
}