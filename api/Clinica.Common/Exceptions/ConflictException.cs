namespace Clinica.Common.Exceptions;

public class ConflictException : Exception
{
    public ConflictException()
    {
    }

    public ConflictException(string name) : base(name)
    {
    }

    public ConflictException(string name,  object key) : base($"Entity \"{name}\" ({key}) already exists.")
    {
    }
}