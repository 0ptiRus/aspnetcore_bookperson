namespace classwork20_12.Classes
{
    public interface IObjectParser<T>
    {
        List<T> Parse(string content, string separator);
    }

}
