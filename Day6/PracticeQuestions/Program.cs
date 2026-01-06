// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Net.WebSockets;

namespace PracticeQuestions;
public class Program
{
    public static void Main()
    {
        Cake obj=new Cake();
        Console.ForegroundColor=ConsoleColor.Blue;
        Console.WriteLine("Enter ur Favourite flavour");
        obj.Flavour=Console.ReadLine();
        Console.WriteLine("Enter kitna khaana hai in kg");
        obj.QuantityInKg=Int32.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter 1 kg ka price");
        obj.PricePerKg=Int32.Parse(Console.ReadLine()!);

        try
        {
            if (obj.CakeOrder())
            {
                Console.ForegroundColor=ConsoleColor.Green;
                Console.WriteLine("Cake order was Succesful");
                double finalprice=obj.CalculatePrice();
                Console.ForegroundColor=ConsoleColor.Yellow;
                Console.WriteLine($"price afte dicount is {finalprice}/-");
            }
        }
        catch(InvalidFlavourException e)
        {
            System.Console.WriteLine(e.Message);
        }
        catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
            
        }



        
    }
}