using System;

public class Program
{
public static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            ShowMenu();
            Console.Write("Enter your option: ");
            string input = Console.ReadLine()!;

            int option;
            bool isNumber = int.TryParse(input, out option);

            if (!isNumber)
            {   
                Console.WriteLine("Invalid input, Please enter a number.");
                continue;
            }

            switch (option)
            {
                case 1:
                    BillingService.CreateNewBill();
                    break;

                case 2:
                    BillingService.ViewLastBill();
                    break;

                case 3:
                    BillingService.ClearLastBill();
                    break;

                case 4:
                    Console.ForegroundColor=ConsoleColor.Green;
                    Console.WriteLine("Thank you, Application closed!!.");
                    exit = true;
                    break;

                default:
                    Console.ForegroundColor=ConsoleColor.Red;
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.ForegroundColor=ConsoleColor.White;
        Console.WriteLine("\n================== MediSure Clinic Billing ==================");
        Console.WriteLine("1. Create New Bill (Enter Patient Details)");
        Console.WriteLine("2. View Last Bill");
        Console.WriteLine("3. Clear Last Bill");
        Console.WriteLine("4. Exit");
    }
}
