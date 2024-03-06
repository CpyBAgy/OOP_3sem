using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class RouteUnpassableException : Exception
{
    public RouteUnpassableException()
        : base("None of the ships can complete the route.") { }

    public RouteUnpassableException(string message)
        : base(message) { }

    public RouteUnpassableException(string message, Exception innerException)
        : base(message, innerException) { }
}
