using Utils;

var elfPairsInput = ProblemHelpers.ReadProblemInputFromFile<ElfPairsInput>("input.txt", sr => new ElfPairsInputParser(sr));

{ // Part 1
    var count = elfPairsInput.ElfPairDetails
        .Count(
            ep =>
            {
                (var shortest, var longest) = ep.FirstElfRange.Count < ep.SecondElfRange.Count
                ? (ep.FirstElfRange, ep.SecondElfRange)
                : (ep.SecondElfRange, ep.FirstElfRange);

                return longest.Intersect(shortest).SequenceEqual(shortest);
            });

    Console.WriteLine("---- PART 1 ----");
    Console.WriteLine(count);
}

{   // Part 2

    var count = elfPairsInput.ElfPairDetails.Count(
        ep => ep.FirstElfRange.Any(section => ep.SecondElfRange.Contains(section)) 
            || ep.SecondElfRange.Any(section => ep.FirstElfRange.Contains(section))
    );

    Console.WriteLine("---- PART 2 ----");
    Console.WriteLine(count);
}