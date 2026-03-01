using System;

namespace HotelBillingSystem;

public interface IRoom
{
    double CalculateBill(int nights, int joiningYear);

    int GetMembershipYears(int joiningYear);
    
}
