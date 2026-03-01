using System;

namespace EmployeeSalary;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }    

    public double Salary { get; set; } 

    public Employee(int id, string name, double salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Salary: {Salary}");
    }
    

}
