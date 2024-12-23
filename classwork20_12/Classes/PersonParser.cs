namespace classwork20_12.Classes
{
    public class PersonParser : IObjectParser<Person>
    {
        public List<Person> Parse(string content, string separator)
        {
            string[] lines = content.Split(separator);
            return lines.Select(line => line.Trim())
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Select(ParsePersonFromString)
                        .ToList();
        }

        private Person ParsePersonFromString(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length != 4)
            {
                throw new InvalidDataException("Неверный формат строки");
            }

            return new Person
            (
                parts[0].Trim(),
                parts[1].Trim(),
                DateTime.Parse(parts[2].Trim()),
                parts[3].Trim()
            );
        }
    }
}
