using System;

namespace Day3;

public class Quadratic
{
    public void QuadraticMAin()
    {
        bool isX=int.TryParse(Console.ReadLine(), out int x);
        bool isY=int.TryParse(Console.ReadLine(), out int y);
        if (!(isX || isY))
        {
            Console.WriteLine("Invalid input");
        }
        if(x>0 && y > 0)
        {
            Console.WriteLine("First Quadrant");
        }
        else if(x<0 && y>0)
        {
            Console.WriteLine("Second Quadrant");
        }
        else if(x<0 && y<0)
        {
            Console.WriteLine("Third Quadrant");
        }
        else if(x>0 && y<0)
        {
            Console.WriteLine("Fourth Quadrant");
        }
        else
        {
            Console.WriteLine("Origin");
        }


    }

}
