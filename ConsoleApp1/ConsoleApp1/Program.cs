using System;

namespace LibrarySystem
{

    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public abstract void GetInfo();
    }

    public interface IDownloadable
    {
        void Download();
    }

    public class Book : LibraryItem
    {
        public int PageCount { get; set; }

        public override void GetInfo()
        {
            Console.WriteLine($"[Паперова книга] Назва: '{Title}', Автор: {Author}, Сторінок: {PageCount}");
        }
    }

    public class EBook : LibraryItem, IDownloadable
    {
        public double FileSizeMB { get; set; }

        public override void GetInfo()
        {
            Console.WriteLine($"[Електронна книга] Назва: '{Title}', Автор: {Author}, Розмір файлу: {FileSizeMB} МБ");
        }

        public void Download()
        {
            Console.WriteLine($"--> Завантаження електронної книги '{Title}'... (Залишилося завантажити {FileSizeMB} МБ)");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Book physicalBook = new Book
            {
                Title = "Чистий код",
                Author = "Роберт Мартін",
                PageCount = 464
            };
            EBook digitalBook = new EBook
            {
                Title = "Патерни проєктування",
                Author = "Еріх Гамма",
                FileSizeMB = 5.2
            };

            Console.WriteLine("=== ІНФОРМАЦІЯ ПРО ЕЛЕМЕНТИ БІБЛІОТЕКИ ===\n");

            physicalBook.GetInfo();
            digitalBook.GetInfo();

            Console.WriteLine("\n=== ДЕМОНСТРАЦІЯ ЗАВАНТАЖЕННЯ ===\n");

            digitalBook.Download();

            Console.ReadLine();
        }
    }
}