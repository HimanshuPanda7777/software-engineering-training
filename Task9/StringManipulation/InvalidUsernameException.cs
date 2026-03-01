using System;

namespace StringManipulation;

public class InvalidUsernameException : Exception
{
    public InvalidUsernameException(string message): base(message)
    {
        
    }

}
