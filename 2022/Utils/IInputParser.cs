namespace Utils;
public interface IInputParser<T> where T : class
{
    StreamReader Reader { get; }

    T ParseInput();
}
