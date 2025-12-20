using System;

namespace StudentManagementSystem;

public class StudentBL
{
    Student sObj = null;

    public StudentBL()
    {
        sObj = new Student();
    }

    public void AcceptDetails(Student s)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("-----Enter Student Details-----");
        Console.WriteLine("===============================");
        
        Console.WriteLine("Enter Roll No:");
        sObj.RollNo = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Physics Marks:");
        sObj.Phy = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Chemistry Marks:");
        sObj.Chem = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Maths Marks:");
        sObj.Math = Convert.ToInt32(Console.ReadLine());
    }
}
