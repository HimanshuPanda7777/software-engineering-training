using System;

namespace OOPsDemo;

public class Manager: Employee
{
    public int ManagerID { get; set; }
    public int Incentive { get; set; }

     public override int CalculateSalary(int sal)
    {
        int mySal=0;
        //salary=hra+da+basic-taxes
        mySal=sal+45000+3000+1500-2500;
        return mySal;

    }

    

}
