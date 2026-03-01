using System;
using System.Diagnostics;

namespace Lbm;

public class BookUtility
{
    public List<Book> BookList=new List<Book>();

    public void AddBookDestails()
    {
    string[] input=Console.ReadLine()!.Split(' ');
    

    Book bObj=new Book(input[0],input[1], int.Parse(input[2]),double.Parse(input[3]));
    BookList.Add(bObj);
    }
    public void CalculateTotalRent(string bid)
    {
        Book obj=null;
        foreach(Book b in BookList)
        {
            if (bid == b.BId)
            {
                obj=b;
            }
        }
        double total =obj.DaysRented *obj.DailyRate;
        Console.WriteLine($"Total Rent: {total}");
        
    }
    public void GetBookDetails(string bid)
    {
        Book obj =null;
         foreach(Book b in BookList)
        {
            if (bid == b.BId)
            {
                obj=b;
            }
        }

        Console.WriteLine($"Book: {obj.Title} (ID: {obj.BId}) for {obj.DaysRented} days");
    }

    public void UpdateDaysRented(string bid)
    {
        
        Book obj =null;
         foreach(Book b in BookList)
        {
            if (bid == b.BId)
            {
                obj=b;
            }
        }
        bool check = int.TryParse(Console.ReadLine(),out int updatedr);
        if(check){
            if (updatedr < 0)
            {
                throw new InvalidDaysRented("No of days cant be < 0");
                
            }
        obj.DaysRented=updatedr;
        }
        else
        Console.WriteLine("String cant be null");


    }

}
