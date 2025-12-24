// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Numerics;
using AssignmentHourly2;

public class Program
{
    public Candy CalculateDiscountPrice(Candy c)
    {
        
        c.TotalPrice=c.Quantity*c.PricePerPiece;
        if(c.Flavour=="Strawberry"){
        c.Discount=c.TotalPrice-(c.TotalPrice* 0.15);
        }
        else if(c.Flavour=="Lemon"){
        c.Discount=c.TotalPrice-(c.TotalPrice* 0.10);
        }
        else if(c.Flavour=="Mint"){
        c.Discount=c.TotalPrice-(c.TotalPrice* 0.05);
        }
        return c;


    }
    public static void Main()
    {
        Console.WriteLine("Enetr your Flavour");
        string Flavour=Console.ReadLine()!;
        Console.WriteLine("Enetr your Quantity");
        int Quantity=Int32.Parse(Console.ReadLine()!);
        Console.WriteLine("Enetr your price");
        int PricePerPiece=Int32.Parse(Console.ReadLine()!);

        Candy c=new Candy();
        Program p=new Program();
        if (c.ValidateCandyFlavour(Flavour))
        {
            p.CalculateDiscountPrice(c);
            Console.WriteLine($"Flavour is {c.Flavour}");
              Console.WriteLine($"Quantity is {c.Quantity}");
                Console.WriteLine($"Price is {c.PricePerPiece}");
                  Console.WriteLine($"Total Price is {c.TotalPrice}");
                    Console.WriteLine($"Discount is {c.Discount}");

        }
    else {
        Console.WriteLine("Yeh Flavour Nahi milege");
    }
         
        


    }
}