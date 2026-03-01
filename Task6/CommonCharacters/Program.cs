using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter word1: ");
        string word1 = Console.ReadLine();

        Console.Write("Enter word2: ");
        string word2 = Console.ReadLine();

        int deleteCount = 0;

        for (int i = 0; i < word1.Length; i++)
        {
            bool found = false;

            for (int j = 0; j < word2.Length; j++)
            {
                if (word1[i] == word2[j])
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                deleteCount++;
            }
        }

        Console.WriteLine("Characters to be deleted from word1: " + deleteCount);
    }
}
