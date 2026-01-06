using System;

namespace PracticeQuestions;

public class Cake 
{
     public string? Flavour{get; set;}
    public int QuantityInKg{get; set;}
    public double PricePerKg{get; set;}

    public bool CakeOrder()
    {
        if(Flavour!="Chocolate" && Flavour!="Vanilla" && Flavour!="Red Velvet")
        {
            throw new InvalidFlavourException("This Flavour is not valid");
            
            
        }
        if (QuantityInKg <= 0)
        {
            throw new InvalidFlavourException("Quantitiy cant be less than zero or zero");
            
        }
        return true;

    }
    public double CalculatePrice()
    {
        double total=QuantityInKg*PricePerKg;
        double dp=0;
        if (Flavour== "Vanilla")
        {
            dp=total-(total*0.03);
            
        }
        if (Flavour == "Chocolate")
        {
            dp=total-(total*0.05);
            
        }
        if (Flavour == "Red Velvet")
        {
            dp=total-(total*0.10);
            
        }
        return dp;
        
    }

}
