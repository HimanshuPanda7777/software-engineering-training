using System;

namespace HotelBillingSystem;
public class HotelRoom : IRoom
{
    private string guestName;
    private string roomType;
    private double pricePerNight;

    public HotelRoom(string name, string type, double price)
    {
        guestName = name;
        roomType = type;
        pricePerNight = price;
    }

    public string GuestName()
    {
        return guestName;
    }

    public string RoomType()
    {
        return roomType;
    }

    public double PricePerNight()
    {
        return pricePerNight;
    }

    public int GetMembershipYears(int joiningYear)
    {
        int currentYear = 2025;
        return currentYear - joiningYear;
    }

    public double CalculateBill(int nights, int joiningYear)
    {
        double totalAmount = nights * pricePerNight;
        int membershipYears = GetMembershipYears(joiningYear);

        if (membershipYears > 3)
        {
            totalAmount = totalAmount - (totalAmount * 0.10);
        }

        return Math.Round(totalAmount);
    }
}

