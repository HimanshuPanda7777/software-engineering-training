using System;
public class University
{
    public void Write()
    {
        Console.WriteLine("Welcome to the University!");
    }
    class Section : University
    {
        public void Display()
        {
            Console.WriteLine("This is a section of the University.");
        }
    }
    class RoomNo : Section
    {
        public void Show()
        {
            Console.WriteLine("This is a room number in the section.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RoomNo room = new RoomNo();
            room.Write();    // Inherited from University
            room.Display();  // Inherited from Section
            room.Show();     // Defined in RoomNo
        }
    }
}