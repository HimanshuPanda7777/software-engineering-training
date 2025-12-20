using System;

namespace Day3;

public class Fabonacci
{
    public void FabonacciMain()
    {
        int n1=0;int n2=1;
        bool xcheck=int.TryParse(Console.ReadLine(), out int x);
        if (!xcheck)
        {
            Console.WriteLine("Invalid");
        }
        else 
        Console.Write("0 1");
        
            for(int i = 2; i <= x; i++)
            {
                int next=n1+n2;
                
                Console.Write($" { next} ");
                n1=n2;
                n2=next;
                
                
            }
        
    }
}
