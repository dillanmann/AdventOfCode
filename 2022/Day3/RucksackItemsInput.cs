public class RucksackItemsInput
{
    public List<Rucksack> Rucksacks { get; init; } = new List<Rucksack>(); 
}

public class Rucksack
{
    public string AllItems { get; init; }
    
    public List<RucksackCompartment> Compartments { get; init; } = new List<RucksackCompartment>();
}

public class RucksackCompartment
{
    public string Items { get; init; }
}