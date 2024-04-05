using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a library
        Library library = new Library("Central Library", "123 Main St");

        // Add books
        library.AddBook(new Book("The Catcher in the Rye", "J.D. Salinger", "978-0316769488", 1951));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "978-0060935467", 1960));

        // Add media items
        library.AddMediaItem(new MediaItem("Inception", "DVD", 148));
        library.AddMediaItem(new MediaItem("The Dark Side of the Moon", "CD", 42));

        // Print catalog
        library.PrintCatalog();

        // Bonus: Search for an item
        Console.WriteLine("\nSearch Results:");
        var searchResults = library.Search("The");
        foreach (var item in searchResults)
        {
            Console.WriteLine(item);
        }
    }
}

class Library
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Book> Books { get; set; }
    public List<MediaItem> MediaItems { get; set; }

    public Library(string name, string address)
    {
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine($"{Name} - {Address}");
        Console.WriteLine("Books:");
        foreach (var book in Books)
        {
            Console.WriteLine(book);
        }
        Console.WriteLine("Media Items:");
        foreach (var item in MediaItems)
        {
            Console.WriteLine(item);
        }
    }

    public List<string> Search(string keyword)
    {
        List<string> results = new List<string>();
        foreach (var book in Books)
        {
            if (book.Title.Contains(keyword) || book.Author.Contains(keyword) || book.ISBN.Contains(keyword))
            {
                results.Add(book.ToString());
            }
        }
        foreach (var item in MediaItems)
        {
            if (item.Title.Contains(keyword) || item.MediaType.Contains(keyword))
            {
                results.Add(item.ToString());
            }
        }
        return results;
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} ({PublicationYear}) - ISBN: {ISBN}";
    }
}

class MediaItem
{
    public string Title { get; set; }
    public string MediaType { get; set; }
    public int Duration { get; set; }

    public MediaItem(string title, string mediaType, int duration)
    {
        Title = title;
        MediaType = mediaType;
        Duration = duration;
    }

    public override string ToString()
    {
        return $"{Title} - {MediaType} ({Duration} minutes)";
    }
}
