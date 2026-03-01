using System;

namespace Lbm;

public class InvalidDaysRented : Exception
{
    public InvalidDaysRented(string message) : base(message)
    {
        
    }


}
