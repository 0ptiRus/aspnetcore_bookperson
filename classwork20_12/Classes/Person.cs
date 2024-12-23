namespace classwork20_12.Classes
{
    public interface IObjectWriter<T>
    {
        void Write(T input);
    }

    public class ConsolePersonWriter : IObjectWriter<Person>
    {
        public void Write(Person person)
        {
            Console.WriteLine($"Имя: {person.Name}");
            Console.WriteLine($"Фамилия: {person.Surname}");
            Console.WriteLine($"Дата рождения: {person.Birthday:d}");
            Console.WriteLine($"Страна рождения: {person.Country}");
        }
    }

    public class FilePersonWriter(string filePath) : IObjectWriter<Person>
    {
        private readonly string file_path = filePath;

        public void Write(Person person)
        {
            using StreamWriter writer = new(file_path);
            writer.WriteLine($"Имя: {person.Name},");
            writer.WriteLine($"Фамилия: {person.Surname},");
            writer.WriteLine($"Дата рождения: {person.Birthday:d},");
            writer.WriteLine($"Страна: {person.Country}");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }

        public Person(string name, string surname, DateTime birthday, string country)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Country = country;
        }

        public void Display(IObjectWriter<Person> writer)
        {
            writer.Write(this);
        }
    }
}
