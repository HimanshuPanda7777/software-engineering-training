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

            if (!int.TryParse(input, out int option))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (option)
            {
                case 1:
                    BillingService.CreateNew();
                    break;

                case 2:
                    BillingService.ViewLastTransaction();
                    break;

                case 3:
                    BillingService.RecalculateProfitLoss();
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thank you. Application closed normally.");
                    Console.ResetColor();
                    exit = true;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option! Please try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n================== QuickMart ==================");
        Console.WriteLine("1. Register Transaction (Enter Details)");
        Console.WriteLine("2. View Last Transaction");
        Console.WriteLine("3. Recalculate Profit / Loss");
        Console.WriteLine("4. Exit");
        Console.ResetColor();
    }
}
