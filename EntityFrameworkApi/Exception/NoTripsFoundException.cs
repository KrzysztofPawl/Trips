namespace EntityFrameworkApi.Exception;

public class NoTripsFoundException : System.Exception
{
    public NoTripsFoundException() : base("No trips found")
    {
    }

    public NoTripsFoundException(string message) : base(message)
    {
    }

    public NoTripsFoundException(string message, System.Exception inner) : base(message, inner)
    {
    }
}