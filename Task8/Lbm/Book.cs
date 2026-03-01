using System;

namespace Lbm;

public class Book
{
    public string ? BId{get; set;}
    public string ? Title{get; set;}
    public int DaysRented{get; set;}
    public double DailyRate{get; set;}

    public Book(string id, string title, int dr, double dr2)
    {
        BId=id;
        Title=title;
        DaysRented=dr;
        DailyRate=dr2;

    }

}

