using System;

public class InvalidFlavourException : Exception
{
    public InvalidFlavourException(string message) : base(message)
    {
    }
}