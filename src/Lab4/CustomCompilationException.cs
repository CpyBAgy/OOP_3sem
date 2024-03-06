using System;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CustomCompilationException : Exception
{
    public CustomCompilationException() { }

    public CustomCompilationException(string message)
        : base(message) { }

    public CustomCompilationException(string message, Exception innerException)
        : base(message, innerException) { }
}
