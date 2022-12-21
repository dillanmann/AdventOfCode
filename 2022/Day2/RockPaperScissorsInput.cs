public class RockPaperScissorsInput
{
    public List<RockPaperScissorsRound> Rounds { get; } = new List<RockPaperScissorsRound>();
}

public struct RockPaperScissorsRound
{
    public string OpponentMove { get; init; }
    public string YourMove { get; init; }
}