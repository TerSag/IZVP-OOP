using System;
using System.Collections.Generic;
using System.Linq;

namespace BookCatalogMVC
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class BookModel
    {
        private List<Book> _catalog = new List<Book>();
        private int _nextId = 1;

        public void AddBook(string title, string author)
        {
            _catalog.Add(new Book { Id = _nextId++, Title = title, Author = author });
        }

        public List<Book> GetAllBooks()
        {
            return _catalog;
        }

        public List<Book> SearchBooks(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return new List<Book>();
            return _catalog.Where(b => b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public bool DeleteBook(int id)
        {
            var book = _catalog.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _catalog.Remove(book);
                return true;
            }
            return false;
        }
    }

    public class BookView
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n--- Каталог книг ---");
            Console.WriteLine("1. Додати книгу");
            Console.WriteLine("2. Показати каталог");
            Console.WriteLine("3. Знайти книгу");
            Console.WriteLine("4. Видалити книгу");
            Console.WriteLine("5. Вихід");
            Console.Write("Оберіть дію: ");
        }

        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowBooks(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Каталог порожній або нічого не знайдено.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"[ID: {book.Id}] {book.Title} — {book.Author}");
            }
        }
    }

    public class BookController
    {
        private BookModel _model;
        private BookView _view;

        public BookController(BookModel model, BookView view)
        {
            _model = model;
            _view = view;
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                _view.ShowMenu();
                string choice = _view.GetInput("");

                switch (choice)
                {
                    case "1":
                        AddBookFlow();
                        break;
                    case "2":
                        ShowCatalogFlow();
                        break;
                    case "3":
                        SearchBookFlow();
                        break;
                    case "4":
                        DeleteBookFlow();
                        break;
                    case "5":
                        running = false;
                        _view.ShowMessage("Програму завершено.");
                        break;
                    default:
                        _view.ShowMessage("Некоректний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        private void AddBookFlow()
        {
            string title = _view.GetInput("Введіть назву книги: ");
            string author = _view.GetInput("Введіть автора книги: ");

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                _view.ShowMessage("Помилка: Назва та автор не можуть бути порожніми.");
                return;
            }

            _model.AddBook(title, author);
            _view.ShowMessage($"Додано: {title} — {author}");
        }

        private void ShowCatalogFlow()
        {
            var books = _model.GetAllBooks();
            _view.ShowMessage("\n--- Весь каталог ---");
            _view.ShowBooks(books);
        }

        private void SearchBookFlow()
        {
            string keyword = _view.GetInput("Введіть назву для пошуку: ");
            var results = _model.SearchBooks(keyword);

            _view.ShowMessage($"Пошук «{keyword}»: знайдено {results.Count} книгу(и)");
            _view.ShowBooks(results);
        }

        private void DeleteBookFlow()
        {
            string idStr = _view.GetInput("Введіть ID книги для видалення: ");
            if (int.TryParse(idStr, out int id))
            {
                if (_model.DeleteBook(id))
                {
                    _view.ShowMessage($"Книгу з ID {id} успішно видалено.");
                }
                else
                {
                    _view.ShowMessage("Помилка: Книгу з таким ID не знайдено.");
                }
            }
            else
            {
                _view.ShowMessage("Помилка: Некоректний формат ID.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            BookModel model = new BookModel();
            BookView view = new BookView();
            BookController controller = new BookController(model, view);

            controller.Run();
        }
    }
}