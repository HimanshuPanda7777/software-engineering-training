using System;

namespace OOPsDemo;

public class Employee
{
    #region Properties
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public double BasicSal{ get; set; }
    #endregion
    public int CalculateSalary(int sal)
    {
        int mySal=0;
        //salary=hra+da+basic-taxes
        mySal=sal+15000+3000+1500-2500;
        return mySal;

    }

}
