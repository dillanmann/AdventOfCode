using Utils;

public class ElfPairsInputParser : IInputParser<ElfPairsInput>
{
    public StreamReader Reader { get; }

    public ElfPairsInputParser(StreamReader reader)
    {
        Reader = reader;
    }

    public ElfPairsInput ParseInput()
    {
        var inputModel = new ElfPairsInput();

        string line;
        while ((line = Reader.ReadLine()) != null)
        {
            var pairs = line.Split(',').SelectMany(s => s.Split('-')).Select(s => int.Parse(s)).ToArray();
            inputModel.ElfPairDetails.Add(
                new ElfPairDetails(pairs[0], pairs[1], pairs[2], pairs[3]));
        }

        return inputModel;
    }
}