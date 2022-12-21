using Utils;

public class RockPaperScissorsInputParser : IInputParser<RockPaperScissorsInput>
{
    public StreamReader Reader { get; }

    public RockPaperScissorsInputParser(StreamReader reader)
    {
        Reader = reader;
    }

    public RockPaperScissorsInput ParseInput()
    {
        var inputModel = new RockPaperScissorsInput();

        string line;
        while ((line = Reader.ReadLine()) != null)
        {
            var moves = line.Split(' ');
            inputModel.Rounds.Add(
                new RockPaperScissorsRound
                {
                    OpponentMove = moves[0],
                    YourMove = moves[1]
                });
        }

        return inputModel;
    }
}
