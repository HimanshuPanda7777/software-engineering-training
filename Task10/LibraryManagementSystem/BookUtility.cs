using System;

namespace LibraryManagementSystem;

public class BookUtility
{
    List<Book> bookList=new List<Book>();
    public void AddBook(string title, string author, string genre, int py)
    {
        Book b=new Book();
        b.Title=title;
        b.Author=author;
        b.Genre=genre;
        b.PublicationYear=py;



        bookList.Add(b);
        Console.WriteLine("Book added successfully");
    }

    public SortedDictionary<string, List<Book> GroupBooksByGenre()
    {
        SortedDictionary<string, List<Book>> groupedBooks = new SortedDictionary<string,List<Book>>();
        for(int i = 0; i < bookList.Count; i++)
        {
            string genre=bookList[i].Genre;
            if (!(groupedBooks.ContainsKey(genre)))
            {
                groupedBooks[genre]=new List<Book>();

            }
            groupedBooks[genre].Add(bookList[i]);
            
        }
        return groupedBooks;



        
    }

}
