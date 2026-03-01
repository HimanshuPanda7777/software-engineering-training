using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter employment type: ");
            string employmentType = Console.ReadLine();

            Console.Write("Enter monthly income: ");
            double monthlyIncome = double.Parse(Console.ReadLine());

            Console.Write("Enter existing credit dues: ");
            double dues = double.Parse(Console.ReadLine());

            Console.Write("Enter credit score: ");
            int creditScore = int.Parse(Console.ReadLine());

            Console.Write("Enter number of loan defaults: ");
            int defaults = int.Parse(Console.ReadLine());

           
            CreditRiskProcessor.ValidateCustomerDetails(
                age,
                employmentType,
                monthlyIncome,
                dues,
                creditScore,
                defaults);

            
            double creditLimit = CreditRiskProcessor.CalculateCreditLimit(
                monthlyIncome,
                dues,
                creditScore,
                defaults);

            Console.WriteLine("Customer Name: " + name);
            Console.WriteLine("Approved Credit Limit: ₹" + creditLimit);
        }
        catch (InvalidCreditDataException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input format");
        }
    }
}