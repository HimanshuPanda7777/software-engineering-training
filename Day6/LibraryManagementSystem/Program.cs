// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Runtime.InteropServices;
using LibraryManagementSystem;

public class Program
{
    public static void Main()
    {
        string title, author; DateTime dueDate, returnedDate;
        int numPages;
        
        System.Console.WriteLine("Enter Title");
        title =System.Console.ReadLine()!;
        System.Console.WriteLine("Enter author name");
        author=Console.ReadLine()!;
        System.Console.WriteLine("Enter no of pages");
        numPages=Int32.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter due date");
        dueDate=DateTime.ParseExact(Console.ReadLine()!,"MM/dd/yyyy",null);
        System.Console.WriteLine("Enter return date");
        returnedDate=DateTime.ParseExact(Console.ReadLine()!,"MM/dd/yyyy",null);

        Book b=new Book(title, author, numPages, dueDate, returnedDate);
        System.Console.WriteLine("Enter the days to read");
        int Days=Int32.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter daily late fee");
        int lateFee=Int32.Parse(Console.ReadLine()!);
        Console.ForegroundColor=ConsoleColor.Green;
        Console.WriteLine($"Average Pages Read Per Day = {b.AveragePagesReadPerDay(Days)}");
        Console.WriteLine($"Late fee is : {b.CalculateLateFee(lateFee)}");


    }
}
