using Utils;

public class ElfInputParser : IInputParser<ElfInput>
{
    public ElfInputParser(StreamReader reader)
    {
        Reader = reader;
    }

    public StreamReader Reader { get; }

    public ElfInput ParseInput()
    {
        var elfInput = new ElfInput();

        string line;
        while ((line = Reader.ReadLine()) != null)
        {
            int? calories = string.IsNullOrWhiteSpace(line) 
            ? null
            : int.Parse(line);
            elfInput.ElfCalories.Add(calories);
        }

        return elfInput;
    }
}