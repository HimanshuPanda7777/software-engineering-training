

public class Program
{
    public static void Main(string[] args)
    {
     int[] empIds = { 101, 102, 103 };
     Array.Sort(empIds);
     int highestId = empIds[empIds.Length - 2];
     Console.WriteLine("Highest Employee ID: " + highestId);
    }
}       