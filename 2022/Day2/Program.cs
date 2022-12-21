using Utils;

const int Loss = 0;
const int Draw = 3;
const int Win = 6;
var moveScores = new Dictionary<string, int>
{
    { "A", 1 },
    { "B", 2 },
    { "C", 3 },
    { "X", 1 },
    { "Y", 2 },
    { "Z", 3 }
};
var complementaryWinningMoves = new Dictionary<string, string>
{
    { "A", "Y" },
    { "B", "Z" },
    { "C", "X" }
};
var complementaryLosingMoves = new Dictionary<string, string>
{
    { "A", "Z" },
    { "B", "X" },
    { "C", "Y" }
};
var equivalentMoves = new Dictionary<string, string>
{
    { "A", "X" },
    { "B", "Y" },
    { "C", "Z" },
};

var rpsInput = ProblemHelpers.ReadProblemInputFromFile<RockPaperScissorsInput>("input.txt", sr => new RockPaperScissorsInputParser(sr));

{   // Part 1
    var score = 0;
    foreach (var round in rpsInput.Rounds)
    {
        var yourMove = round.YourMove;
        var opponentMove = round.OpponentMove;
        score += CalculateScoreFromRound(yourMove, opponentMove);
    }

    Console.WriteLine($"Total score: {score}");
}

{    // Part 2
    var score = 0;
    foreach (var round in rpsInput.Rounds)
    {
        var opponentMove = round.OpponentMove;
        var roundResult = round.YourMove;
        string yourMove;

        // Loss
        if (roundResult == "X")
        {
            yourMove = complementaryLosingMoves[opponentMove];
        }
        // Draw
        else if (roundResult == "Y")
        {
            yourMove = equivalentMoves[opponentMove];
        }
        else
        {
            yourMove = complementaryWinningMoves[opponentMove];
        }

        score += CalculateScoreFromRound(yourMove, opponentMove);
    }

    Console.WriteLine($"Total score: {score}");
}

int CalculateScoreFromRound(string yourMove, string opponentMove)
{
    if (moveScores[opponentMove] == moveScores[yourMove])
    {
        // Draw
        return Draw + moveScores[yourMove];
    }

    if (yourMove == complementaryWinningMoves[opponentMove])
    {
        // Win
        return  Win + moveScores[yourMove];
    }

    // Loss
    return Loss + moveScores[yourMove];
}