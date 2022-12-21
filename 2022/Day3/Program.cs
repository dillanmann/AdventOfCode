using Utils;

var rucksackInput = ProblemHelpers.ReadProblemInputFromFile<RucksackItemsInput>("input.txt", sr => new RucksackItemsInputParser(sr));

{   // Part 1
    var commonElementsInRucksack = rucksackInput
        .Rucksacks
        .SelectMany(
            r => new string(r.Compartments.First().Items.Intersect(r.Compartments.Last().Items).ToArray()));

    var commonElementsAsPriorities = commonElementsInRucksack.Select(MapCharToAlphabetIndex);
    var sumOfPriorities = commonElementsAsPriorities.Sum();

    Console.WriteLine("---- PART 1 ----");
    Console.WriteLine($"Common letters in each rucksack: {string.Join(",", commonElementsInRucksack)}");
    Console.WriteLine($"Common letters as priorities: {string.Join(",", commonElementsAsPriorities)}");
    Console.WriteLine($"Sum of priorities: {sumOfPriorities}");
    Console.WriteLine();
}

{   // Part 2
    var groupedRucksacks = rucksackInput.Rucksacks.Chunk(3);
    var commonElementsPerGroup = groupedRucksacks.SelectMany(group => group[0].AllItems.Intersect(group[1].AllItems.Intersect(group[2].AllItems)));
    var commonElementsPerGroupAsPriorities = commonElementsPerGroup.Select(MapCharToAlphabetIndex);
    var sumOfGroupElements = commonElementsPerGroupAsPriorities.Sum();

    Console.WriteLine("---- PART 2 ----");
    Console.WriteLine($"Common elements per group: {string.Join(",", commonElementsPerGroup)}");
    Console.WriteLine($"Sum of grouped elements: {sumOfGroupElements}");
}

// Lowercase 'a' is 97, uppercase 'A' is 65. Adjust so that lowercase 'a' = 1 and uppercase 'a' = 27.
int MapCharToAlphabetIndex(char character) => character >= 97 ? character - 96 : character - 38;
