using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Swift;
using BikeRentalApp;

public class Program
{
    public static SortedDictionary<int, Bike> bikeDetails=
    new SortedDictionary<int, Bike>();
    public static void Main(string[] args)
    {
        BikeUtility bikeUtility=new BikeUtility();
        int choice;
        do
        {
        
        Console.WriteLine("1. Add Bike Details");
        Console.WriteLine("2. Groups Bikes By Brand");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Enter Your Choice");

        choice =int.Parse((Console.ReadLine()!));

            switch (choice)
            {
                case 1:
                Console.WriteLine("Enter the model");
                string model=Console.ReadLine();
                System.Console.WriteLine("Enetr the brand");
                string brand= Console.ReadLine();
                Console.WriteLine("Enter the price per day");
                int price=int.Parse((Console.ReadLine()!));

                bikeUtility.AddBikeDetails(model, brand, price);
                break;

                case 2:
                var groupedBikes = bikeUtility.GroupBikesByBrand();
                foreach(var brandEntry in groupedBikes)
                    {

                        Console.WriteLine(brandEntry.Key);
                    foreach(var bike in brandEntry.Value)
                        {
                            System.Console.WriteLine(bike.Model);
                        }
                    Console.WriteLine();
                    }
                    break;

                case 3:
                break;

                default:
                System.Console.WriteLine("Invalid Choice ");
                break;
            }
        }while(choice!=3);


    }
}