using System;
using System.Runtime.InteropServices;
using Lbm;
public class Program
{
    public static void Main(){
        
    
    BookUtility utility=new BookUtility();
        while (true)
        {
            Console.WriteLine("1. Display Book Details");
            Console.WriteLine("2. Calculate and display total rent");
            Console.WriteLine("3. Update DaysRented ");
            Console.WriteLine("4. To Exit ");

            int choice=int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:
                utility.GetBookDetails();
                break;
                case 2:
                utility.CalculateTotalRent();
                break;
                case 3:
                try{
                utility.UpdateDaysRented();
                }
                    catch(InvalidDaysRented ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                break;
                case 4:
                Console.WriteLine("Exiting.........");
                return;
                
                default:
                System.Console.WriteLine("Invalid choice");
                break;

                
                
            }
        }





    }



}