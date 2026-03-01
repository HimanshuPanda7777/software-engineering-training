using System;
using System.Security.AccessControl;
using StringManipulation;
public class Program
{
    public static void Main()
    {
        ProcessString ps=new ProcessString();


        while (true)
        {
            System.Console.WriteLine("Enter the sentence ");
        string sentence=Console.ReadLine()!;
            if (sentence.Equals("exit"))
            {
                return;
            }

            try
            {
                Console.WriteLine(ps.UsernameValidate(sentence));

            }
            catch(InvalidUsernameException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
        

    }
}