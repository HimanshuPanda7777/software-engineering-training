using System;

namespace conditionalAPP;

public class height
{
    public  void HeightMain()
    {
        Console.Write("Enter height in cm: ");
       bool isValid=int.TryParse(Console.ReadLine(),out int height);
        if (!isValid)
        {
            Console.WriteLine("Invalid Output");
        }

        else if (height < 150)
            Console.WriteLine("Dwarf");
        else if (height >= 150 && height < 165)
            Console.WriteLine("Average");
        else if (height >= 165 && height <= 190)
            Console.WriteLine("Tall");
        else
            Console.WriteLine("Abnormal");
    }
}

