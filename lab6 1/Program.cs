using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

interface ILibraryItem
{
    string GetAuthor();
    string GetTitle();
    string GetPublisher();
    int GetYear();
}

class Book : ILibraryItem
{
    public string Author { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public int Year { get; set; }

    public Book(string author, string title, string publisher, int year)
    {
        Author = author;
        Title = title;
        Publisher = publisher;
        Year = year;
    }

    public string GetAuthor()
    {
        return Author;
    }

    public string GetTitle()
    {
        return Title;
    }

    public string GetPublisher()
    {
        return Publisher;
    }

    public int GetYear()
    {
        return Year;
    }

    public override string ToString()
    {
        return $"{Title} від {Author}, опубліковано {Publisher} у {Year}";
    }

    private bool GetDetails()
    {
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main()
    {
        // Встановлення кодування консолі в UTF-8 для коректного відображення української мови
        Console.OutputEncoding = Encoding.UTF8;

        // Створення колекції книг
        List<ILibraryItem> libraryItems = new List<ILibraryItem>();

        // Додавання книг користувачем
        Console.WriteLine("Додайте 10 книг до колекції:");
        for (int i = 0; i < 10; i++)
        {
            try
            {
                Console.WriteLine($"Книга {i + 1}:");

                // Введення автора
                Console.Write("Введіть автора: ");
                string author = Console.ReadLine();

                // Введення назви книги
                Console.Write("Введіть назву книги: ");
                string title = Console.ReadLine();

                // Введення видавництва
                Console.Write("Введіть видавництво: ");
                string publisher = Console.ReadLine();

                // Введення року видання
                Console.Write("Введіть рік видання: ");
                int year = int.Parse(Console.ReadLine());

                // Додайте книгу до колекції
                libraryItems.Add(new Book(author, title, publisher, year));
                Console.WriteLine("Книга додана до колекції.\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоректні дані! Будь ласка, введіть правильний формат.");
                i--; // Повторіть спробу для цієї книги
            }
        }

        // Пошук книг, які містять слово "програмування" у назві
        var programmingBooks = libraryItems
            .Where(item => item is Book) // Фільтруємо лише об'єкти типу Book
            .Cast<Book>() // Приводимо до типу Book
            .Where(book => book.Title.IndexOf("програмування", StringComparison.OrdinalIgnoreCase) >= 0)
            .OrderByDescending(book => book.Year);

        // Вивід результатів
        Console.WriteLine("Книги про програмування:");
        foreach (var book in programmingBooks)
        {
            Console.WriteLine($"{book.GetTitle()} від {book.GetAuthor()}, опубліковано {book.GetPublisher()} у {book.GetYear()}");
        }

        // Очікування для натискання клавіші
        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}
