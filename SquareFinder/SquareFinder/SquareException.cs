using System.Runtime.Serialization;

namespace SquareFinder;

[Serializable]
public class SquareException : Exception
{
    public SquareException()
    {
    }

    protected SquareException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public SquareException(string? message) : base(message)
    {
    }

    public SquareException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
    
