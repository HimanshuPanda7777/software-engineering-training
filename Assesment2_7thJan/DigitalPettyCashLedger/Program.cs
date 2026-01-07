using DigitalPettyCashLedger.Models;
using DigitalPettyCashLedger.Ledger;

class Program
{
    static void Main()
    {
        Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();
        Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

        Console.WriteLine("===== DIGITAL PETTY CASH LEDGER =====\n");

        // ------------------ INCOME INPUT ------------------
        Console.Write("Enter income amount: ");
        double incomeAmount = double.Parse(Console.ReadLine()!);

        Console.Write("Enter income source: ");
        string incomeSource = Console.ReadLine()!;

        Console.Write("Enter income description: ");
        string incomeDescription = Console.ReadLine()!;

        incomeLedger.AddEntry(
            new IncomeTransaction(
                1,
                DateTime.Now,
                incomeAmount,
                incomeDescription,
                incomeSource
            )
        );

        // ------------------ EXPENSE INPUT ------------------
        Console.Write("\nHow many expenses do you want to enter? ");
        int expenseCount = int.Parse(Console.ReadLine()!);

        for (int i = 1; i <= expenseCount; i++)
        {
            Console.WriteLine($"\nExpense #{i}");

            Console.Write("Enter expense amount: ");
            double expenseAmount = double.Parse(Console.ReadLine()!);

            Console.Write("Enter expense category: ");
            string expenseCategory = Console.ReadLine()!;

            Console.Write("Enter expense description: ");
            string expenseDescription = Console.ReadLine()!;

            expenseLedger.AddEntry(
                new ExpenseTransaction(
                    i,
                    DateTime.Now,
                    expenseAmount,
                    expenseDescription,
                    expenseCategory
                )
            );
        }

        // ------------------ CALCULATIONS ------------------
        double totalIncome = incomeLedger.CalculateTotal();
        double totalExpense = expenseLedger.CalculateTotal();
        double netBalance = totalIncome - totalExpense;

        // ------------------ OUTPUT ------------------
        Console.WriteLine("\n===== PETTY CASH SUMMARY =====");
        Console.WriteLine($"Total Income   : ₹{totalIncome}");
        Console.WriteLine($"Total Expense  : ₹{totalExpense}");
        Console.WriteLine($"Net Balance    : ₹{netBalance}");

        Console.WriteLine("\n--- INCOME DETAILS ---");
        foreach (var income in incomeLedger.GetAllTransactions())
        {
            Console.WriteLine(income.GetSummary());
        }

        Console.WriteLine("\n--- EXPENSE DETAILS ---");
        foreach (var expense in expenseLedger.GetAllTransactions())
        {
            Console.WriteLine(expense.GetSummary());
        }
    }
}
