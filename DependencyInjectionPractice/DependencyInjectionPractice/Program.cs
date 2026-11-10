using System;
using System.Collections.Generic;

namespace DependencyInjectionPractice
{
    public class Book
    {
        public string Title { get; set; }

        public Book(string title)
        {
            Title = title;
        }
    }

    public interface IBookRepository
    {
        void Save(Book book);
    }

    public class MemoryRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        public void Save(Book book)
        {
            _books.Add(book);
            Console.WriteLine($"MemoryRepository: додано «{book.Title}».");
            Console.WriteLine($"Книг у пам’яті: {_books.Count}");
        }
    }

    public class ConsoleRepository : IBookRepository
    {
        public void Save(Book book)
        {
            Console.WriteLine($"ConsoleRepository: збережено «{book.Title}».");
        }
    }

    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public void AddBook(string title)
        {
            var book = new Book(title);
            _repository.Save(book);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IBookRepository memoryRepo = new MemoryRepository();
            BookService serviceWithMemory = new BookService(memoryRepo);
            serviceWithMemory.AddBook("Чистий код");

            Console.WriteLine();

            IBookRepository consoleRepo = new ConsoleRepository();
            BookService serviceWithConsole = new BookService(consoleRepo);
            serviceWithConsole.AddBook("Патерни проєктування");

            Console.WriteLine();
            Console.WriteLine("Код BookService не змінювався.");
        }
    }
}