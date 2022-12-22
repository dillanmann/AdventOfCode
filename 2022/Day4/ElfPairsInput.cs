public class ElfPairsInput
{
    public List<ElfPairDetails> ElfPairDetails { get; init; } = new List<ElfPairDetails>();
}

public class ElfPairDetails
{
    public ElfPairDetails(int firstElfStart, int firstElfEnd, int secondElfStart, int secondElfEnd)
    {
        FirstElfAssignments = new Tuple<int, int>(firstElfStart, firstElfEnd);
        SecondElfAssignments = new Tuple<int, int>(secondElfStart, secondElfEnd);
    }

    public Tuple<int, int> FirstElfAssignments { get; }
    public Tuple<int, int> SecondElfAssignments { get; }

    public List<int> FirstElfRange { get => Enumerable.Range(FirstElfAssignments.Item1, FirstElfAssignments.Item2 - FirstElfAssignments.Item1 + 1).ToList(); }
    public List<int> SecondElfRange { get => Enumerable.Range(SecondElfAssignments.Item1, SecondElfAssignments.Item2 - SecondElfAssignments.Item1 + 1).ToList();  }
}