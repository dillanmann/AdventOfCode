using Utils;

var elfInput = ProblemHelpers.ReadProblemInputFromFile<ElfInput>("input.txt", sr => new ElfInputParser(sr));

var runningTotal = 0;
var totalCaloriesPerElf = new List<int>();
foreach(var calories in elfInput.ElfCalories)
{
    if (!calories.HasValue)
    {
        totalCaloriesPerElf.Add(runningTotal);
        runningTotal = 0;
        continue;
    }

    runningTotal += calories.Value;
}


var mostCaloriesCarried = totalCaloriesPerElf.Max();
var indexOfElfWithMostCalories = totalCaloriesPerElf.IndexOf(mostCaloriesCarried);
Console.WriteLine($"The elf with the most calories is elf #{indexOfElfWithMostCalories} with {mostCaloriesCarried} calories.");

// Part 2
var orderedCalories = totalCaloriesPerElf.OrderByDescending(cl => cl);
var sumOfTop3ElvesCalories = orderedCalories.Take(3).Sum();
Console.WriteLine(sumOfTop3ElvesCalories);