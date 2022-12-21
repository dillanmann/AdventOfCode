using Utils;

public class RucksackItemsInputParser : IInputParser<RucksackItemsInput>
{
    public StreamReader Reader { get; }

    public RucksackItemsInputParser(StreamReader reader)
    {
        Reader = reader;
    }

    public RucksackItemsInput ParseInput()
    {
        var inputModel = new RucksackItemsInput();

        string line;
        while ((line = Reader.ReadLine()) != null)
        {
            var splitIndex = line.Length / 2;
            var firstCompartmentContents = line.Substring(0, splitIndex);
            var secondCompartmentContents = line.Substring(splitIndex);

            inputModel.Rucksacks.Add(new Rucksack
            {
                Compartments = new List<RucksackCompartment>()
                {
                    new RucksackCompartment { Items = firstCompartmentContents },
                    new RucksackCompartment { Items = secondCompartmentContents }
                },
                AllItems = line
            });
        }

        return inputModel;
    }
}