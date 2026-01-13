using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace LINQ_ConsoleAPP
{
    class Program
    {
        public static void LinqToObject()
        {
            int[] numArray = { 10, 2, 4, 8, 39, 33, 42, 84, 67, 90, 3, 22 };

            string[] nameArray = { "Himanshu ", "Shreema", "leena", "purva", "Sheryl", "keerti", "Khushi", "Anindita", "Ocean" };
            //foreach (int item in numArray)
            //{
            //    if (item % 2 == 0)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            var result = from data in nameArray
                         where data.Contains("a")
                         select data;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public static void Main(String[] args)
        {
            LinqToObject();
        }
    }
}
    
