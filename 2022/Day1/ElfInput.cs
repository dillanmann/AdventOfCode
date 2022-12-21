public class ElfInput
{
    public ElfInput()
        : this(new List<int?>())
    {        
    }

    public ElfInput(List<int?> elfCalories)
    {
        ElfCalories = elfCalories;
    }

    public List<int?> ElfCalories { get; init; }
}