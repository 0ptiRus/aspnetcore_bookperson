
namespace classwork20_12.Classes
{
    public class BookParser : IObjectParser<Book>
    {
        public List<Book> Parse(string content, string separator)
        {
            var books = content.Split(separator).Select(ParseBookFromString).ToList();
            return books.Where(book => book != null).ToList(); 
        }

        private Book ParseBookFromString(string line)
        {
            try
            {
                string[] parts = line.Split('\n').Select(part => part.Trim()).ToArray();
                if (parts.Length != 5)
                {
                    throw new InvalidDataException("Неверный формат строки");
                }

                return new Book
                {
                    Title = parts[0],
                    Author = parts[1],
                    Style = parts[2],
                    YearOfPublication = int.Parse(parts[3]),
                    OtherInfo = parts[4]
                };
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка при парсинге года издания: {ex.Message}");
                return null;
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine($"Ошибка при парсинге строки: {ex.Message}");
                return null;
            }
        }
    }
}
