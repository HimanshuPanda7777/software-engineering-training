using System;
using QuickMartQuestion2;

public class BillingService
{
    public static SaleTransaction LastTransaction;
    public static bool HasLastTransaction = false;

    public static void CreateNew()
    {
        SaleTransaction stObj = new SaleTransaction();

        Console.Write("Enter Invoice No: ");
        stObj.InvoiceNo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(stObj.InvoiceNo))
        {
            Console.WriteLine("Invoice cannot be empty.");
            return;
        }

        Console.Write("Enter Customer Name: ");
        stObj.CustomerName = Console.ReadLine();

        Console.Write("Enter Item Name: ");
        stObj.ItemName = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
        {
            Console.WriteLine("Quantity must be greater than zero.");
            return;
        }
        stObj.Quantity = qty;

        stObj.PurchaseAmount = ReadDecimal("Enter Purchase Amount (total): ");
        stObj.SellingAmount = ReadDecimal("Enter Selling Amount (total): ");

        CalculateProfitLoss(stObj);

        LastTransaction = stObj;
        HasLastTransaction = true;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nTransaction saved successfully.");
        Console.WriteLine("Status: " + stObj.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + stObj.ProfitOrLossAmount.ToString("0.00"));
        Console.WriteLine("Profit Margin (%): " + stObj.ProfitMarginPercent.ToString("0.00"));
        Console.ResetColor();
        Console.WriteLine("------------------------------------------------------");
    }

    public static void ViewLastTransaction()
    {
        if (!HasLastTransaction)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n-------------- Last Transaction --------------");
        Console.WriteLine("Invoice No: " + LastTransaction.InvoiceNo);
        Console.WriteLine("Customer: " + LastTransaction.CustomerName);
        Console.WriteLine("Item: " + LastTransaction.ItemName);
        Console.WriteLine("Quantity: " + LastTransaction.Quantity);
        Console.WriteLine("Purchase Amount: " + LastTransaction.PurchaseAmount.ToString("0.00"));
        Console.WriteLine("Selling Amount: " + LastTransaction.SellingAmount.ToString("0.00"));
        Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAmount.ToString("0.00"));
        Console.WriteLine("Profit Margin (%): " + LastTransaction.ProfitMarginPercent.ToString("0.00"));
        Console.WriteLine("--------------------------------------------");
        Console.ResetColor();
    }

    public static void RecalculateProfitLoss()
    {
        if (!HasLastTransaction)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            Console.ResetColor();
            return;
        }

        CalculateProfitLoss(LastTransaction);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nRecalculation Completed:");
        Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAmount.ToString("0.00"));
        Console.WriteLine("Profit Margin (%): " + LastTransaction.ProfitMarginPercent.ToString("0.00"));
        Console.ResetColor();
        Console.WriteLine("------------------------------------------------------");
    }

    public static void CalculateProfitLoss(SaleTransaction st)
    {
        if (st.SellingAmount > st.PurchaseAmount)
        {
            st.ProfitOrLossStatus = "PROFIT";
            st.ProfitOrLossAmount = st.SellingAmount - st.PurchaseAmount;
        }
        else if (st.SellingAmount < st.PurchaseAmount)
        {
            st.ProfitOrLossStatus = "LOSS";
            st.ProfitOrLossAmount = st.PurchaseAmount - st.SellingAmount;
        }
        else
        {
            st.ProfitOrLossStatus = "BREAK-EVEN";
            st.ProfitOrLossAmount = 0;
        }

        st.ProfitMarginPercent = (st.ProfitOrLossAmount / st.PurchaseAmount) * 100;
    }

    private static decimal ReadDecimal(string message)
    {
        decimal value;

        while (true)
        {
            Console.Write(message);

            if (decimal.TryParse(Console.ReadLine(), out value))
            {
                if (value >= 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Value cannot be negative.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
