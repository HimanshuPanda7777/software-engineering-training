using System;
using System.Reflection;

namespace LibraryManagementSystem;

public class Book
{
    public string? title{get; set;}
    public string? author{get; set;}
    public int numPages{get;set;}
    public DateTime dueDate{get;set;}
    public DateTime returnedDate{get;set;}

    public Book()
    {
        
    }
    public Book(string title, string author, int numPages,DateTime dueDate, DateTime returnedDate)
    {
        this.title=title;
        this.author=author;
        this.numPages=numPages;
        this.dueDate=dueDate;
        this.returnedDate=returnedDate;

    }
    public double AveragePagesReadPerDay(int daysToRead)
    {
        return numPages/daysToRead;
    }
    public double CalculateLateFee(double dailyLateFeeRate)
    {
        return (returnedDate-dueDate).Days * dailyLateFeeRate;
    }



}
