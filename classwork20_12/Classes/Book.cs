namespace classwork20_12.Classes
{
    public class ConsoleBookWriter : IObjectWriter<Book>
    {
        public void Write(Book book)
        {
            Console.WriteLine($"Название книги: {book.Title}");
            Console.WriteLine($"ФИО автора: {book.Author}");
            Console.WriteLine($"Стиль: {book.Style}");
            Console.WriteLine($"Год издания: {book.YearOfPublication}");
            Console.WriteLine($"Другая информация: {book.OtherInfo}");
        }
    }

    public class FileBookWriter : IObjectWriter<Book>
    {
        private readonly string file_path;

        public FileBookWriter(string filePath)
        {
            file_path = filePath;
        }

        public void Write(Book book)
        {
            using StreamWriter writer = new(file_path);

            writer.WriteLine($"Название книги: {book.Title}");
            writer.WriteLine($"ФИО автора: {book.Author}");
            writer.WriteLine($"Стиль: {book.Style}");
            writer.WriteLine($"Год издания: {book.YearOfPublication}");
            writer.WriteLine($"Другая информация: {book.OtherInfo}");
        }
    }


    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Style { get; set; }
        public int YearOfPublication { get; set; }
        public string OtherInfo { get; set; }

        public void Display(IObjectWriter<Book> writer)
        {
            writer.Write(this);
        }
    }
}
