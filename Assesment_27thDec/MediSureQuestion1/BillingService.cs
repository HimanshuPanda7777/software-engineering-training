using System;
using MediSureQuestion1;

public class BillingService 
{
    public static PatientBill LastBill;
    public static bool HasLastBill = false;

    public static void CreateNewBill()
    {
        PatientBill pbillObj = new PatientBill();

        Console.Write("Enter Bill Id: ");
        pbillObj.BillId = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(pbillObj.BillId))
        {
            Console.WriteLine("Bill Id cannot be empty.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        pbillObj.PatientName = Console.ReadLine();

        Console.Write("Is the patient insured? (Y/N): ");
        string insuranceInput = Console.ReadLine()!;
        pbillObj.HasInsurance = insuranceInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

        pbillObj.ConsultationFee = ReadDecimal("Enter Consultation Fee: ");
        pbillObj.LabCharges = ReadDecimal("Enter Lab Charges: ");
        pbillObj.MedicineCharges = ReadDecimal("Enter Medicine Charges: ");

        pbillObj.GrossAmount = pbillObj.ConsultationFee + pbillObj.LabCharges + pbillObj.MedicineCharges;

        if (pbillObj.HasInsurance)
        {
            pbillObj.DiscountAmount = pbillObj.GrossAmount * 0.10m;
        }
        else
        {
            pbillObj.DiscountAmount = 0;
        }

        pbillObj.FinalPayable = pbillObj.GrossAmount - pbillObj.DiscountAmount;

        LastBill = pbillObj;
        HasLastBill = true;

        Console.ForegroundColor=ConsoleColor.Blue;
        Console.WriteLine("\n---------------------AAPKA BILL-----------------------");
        Console.WriteLine("Gross Amount: " + pbillObj.GrossAmount.ToString("0.00"));
        Console.WriteLine("Discount Amount: " + pbillObj.DiscountAmount.ToString("0.00"));
        Console.WriteLine("Final Payable: " + pbillObj.FinalPayable.ToString("0.00"));
        Console.WriteLine("--------------------------x--------------------------");
    }

    public static void ViewLastBill()
    {
        if (!HasLastBill)
        {   Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("No last bill was available . Please create a new bill first.");
            return;
        }
        Console.ForegroundColor=ConsoleColor.DarkBlue;
        Console.WriteLine("\n----------- Last Bill -----------");
        Console.WriteLine("BillId: " + LastBill.BillId);
        Console.WriteLine("Patient: " + LastBill.PatientName);
        Console.WriteLine("Insured: " + (LastBill.HasInsurance ? "Yes" : "No"));
        Console.WriteLine("Consolttation Fee: " + LastBill.ConsultationFee.ToString("0.00"));
        Console.WriteLine("Lab Charges: " + LastBill.LabCharges.ToString("0.00"));
        Console.WriteLine("Medicine Charges: " + LastBill.MedicineCharges.ToString("0.00"));
        Console.WriteLine("Gross Amount: " + LastBill.GrossAmount.ToString("0.00"));
        Console.WriteLine("Discount Amount: " + LastBill.DiscountAmount.ToString("0.00"));
        Console.WriteLine("Final Payable: " + LastBill.FinalPayable.ToString("0.00"));
        Console.WriteLine("--------------------------------");
    }

    public static void ClearLastBill()
    {
        LastBill = null;
        HasLastBill = false;
        Console.ForegroundColor=ConsoleColor.DarkGreen;
        Console.WriteLine("Last Bill cleared.");
    }
    
    private static decimal ReadDecimal(string message)
{
    decimal value;

    while (true)
    {
        Console.Write(message);

        if (decimal.TryParse(Console.ReadLine(), out value))
        {
            if (value > 0)
            {
                return value;
            }
            else
            {   
                Console.WriteLine("Please enter a number greater than zero.");
            }
        }
        else
        {   
            Console.WriteLine("Invalid input. Enter a valid number.");
        }
    }
}

}
