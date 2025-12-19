using System;

public class largest
{
    public void LargestMain()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        int c = int.Parse(Console.ReadLine());

        int max;

        if (a > b)
        {
            if (a > c)
                max = a;
            else
                max = c;
        }
        else
        {
            if (b > c)
                max = b;
            else
                max = c;
        }

        Console.WriteLine("Largest number is: " + max);
    }
}
