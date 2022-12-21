namespace Utils;
public static class ProblemHelpers
{
    public static TProblemInput ReadProblemInputFromFile<TProblemInput>(
        string filePath,
        Func<StreamReader, IInputParser<TProblemInput>> inputParserFactory)
        where TProblemInput : class
    {
        using (var fileStream = new FileStream(filePath, FileMode.Open))
        using (var inputStream = new StreamReader(fileStream))
        {
            var inputParser = inputParserFactory(inputStream);
            return inputParser.ParseInput();
        }
    }
}