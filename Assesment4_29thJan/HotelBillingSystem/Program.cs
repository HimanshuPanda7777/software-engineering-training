using System;
namespace HotelBillingSystem;

class Program
{
    static void Main()
    {
        // Deluxe Room Input
        Console.WriteLine("Enter Deluxe Room Details");

        Console.Write("Guest Name: ");
        string deluxeName = Console.ReadLine();

        Console.Write("Rate per Night: ");
        double deluxeRate = double.Parse(Console.ReadLine());

        Console.Write("Nights Stayed: ");
        int deluxeNights = int.Parse(Console.ReadLine());

        Console.Write("Joining Year: ");
        int deluxeJoinYear = int.Parse(Console.ReadLine());

        HotelRoom deluxeRoom =
            new HotelRoom(deluxeName, "Deluxe", deluxeRate);

        int deluxeMembership =
            deluxeRoom.GetMembershipYears(deluxeJoinYear);

        double deluxeBill =
            deluxeRoom.CalculateBill(deluxeNights, deluxeJoinYear);
            
        Console.WriteLine("\nEnter Suite Room Details");

        Console.Write("Guest Name: ");
        string suiteName = Console.ReadLine();

        Console.Write("Rate per Night: ");
        double suiteRate = double.Parse(Console.ReadLine());

        Console.Write("Nights Stayed: ");
        int suiteNights = int.Parse(Console.ReadLine());

        Console.Write("Joining Year: ");
        int suiteJoinYear = int.Parse(Console.ReadLine());

        HotelRoom suiteRoom =
            new HotelRoom(suiteName, "Suite", suiteRate);

        int suiteMembership =
            suiteRoom.GetMembershipYears(suiteJoinYear);

        double suiteBill =
            suiteRoom.CalculateBill(suiteNights, suiteJoinYear);


        Console.WriteLine("\nRoom Summary");
        Console.WriteLine("Deluxe Room: " + deluxeRoom.GuestName()
            + ", " + deluxeRoom.PricePerNight()
            + " per night, Membership: "
            + deluxeMembership + " years");

        Console.WriteLine("Suite Room: " + suiteRoom.GuestName()
            + ", " + suiteRoom.PricePerNight()
            + " per night, Membership: "
            + suiteMembership + " years");

        Console.WriteLine("\nTotal Bill");
        Console.WriteLine("For " + deluxeRoom.GuestName()
            + " (Deluxe): " + deluxeBill);

        Console.WriteLine("For " + suiteRoom.GuestName()
            + " (Suite): " + suiteBill);
    }
}
