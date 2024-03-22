using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Book
{
    public string Title { get; set; }
    public int PublicationYear { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
}

public static class BooksLibrary
{
    public static List<Book> GetBooksStartingWithThe(List<Book> books)
    {
        return books.Where(book => book.Title.StartsWith("The", StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public static List<Book> GetBooksByAuthorsWithTInName(List<Book> books)
    {
        return books.Where(book => book.Author.Contains("t", StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public static int GetNumberOfBooksWrittenAfterYear(List<Book> books, int year)
    {
        return books.Count(book => book.PublicationYear > year);
    }

    public static int GetNumberOfBooksWrittenBeforeYear(List<Book> books, int year)
    {
        return books.Count(book => book.PublicationYear < year);
    }

    public static IEnumerable<string> GetIsbnNumbersByAuthor(List<Book> books, string author)
    {
        return books.Where(book => book.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).Select(book => book.Isbn);
    }


    public static void PrintBooks(List<Book> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Title} ({book.PublicationYear}) - {book.Author}");
        }
    }

    public static void Main()
    {
        string json = File.ReadAllText("books.json");
        List<Book> allBooks = JsonSerializer.Deserialize<List<Book>>(json);

        List<Book> booksStartingWithThe = GetBooksStartingWithThe(allBooks);
        Console.WriteLine("Books starting with 'The': ");
        PrintBooks(booksStartingWithThe);

        List<Book> booksByAuthorsWithTInName = GetBooksByAuthorsWithTInName(allBooks);
        Console.WriteLine("\nBooks by authors with 't' in their name: ");
        PrintBooks(booksByAuthorsWithTInName);

        int booksWrittenAfterYearCount = GetNumberOfBooksWrittenAfterYear(allBooks, 1992);
        Console.WriteLine($"\nNumber of books written after 1992: {booksWrittenAfterYearCount}");

        int booksWrittenBeforeYearCount = GetNumberOfBooksWrittenBeforeYear(allBooks, 2004);
        Console.WriteLine($"Number of books written before 2004: {booksWrittenBeforeYearCount}");

        Console.WriteLine("\nISBN numbers by Neil Gaiman:");
        foreach (string isbn in GetIsbnNumbersByAuthor(allBooks, "Neil Gaiman"))
        {
            Console.WriteLine(isbn);
        }

   
    }
}