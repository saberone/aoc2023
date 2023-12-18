using System.Text.RegularExpressions;

namespace AdventOfCode;

public sealed class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
    }
    
    public override ValueTask<string> Solve_1() => new(Sol1());
    
    private string Sol1()
    {
        var strReader = new StringReader(_input);

        int total = 0;
        while(true)
        {
            var aLine = strReader.ReadLine();
            if (aLine == null)
            {
                break;
            }
            
            string gameNumberPattern = @"Game (\d+):";
            Regex regex = new Regex(gameNumberPattern);
            Match match = regex.Match(aLine);
            
            int gameNumber = int.Parse(match.Groups[1].Value);


            var parts = aLine[(aLine.IndexOf(':') + 2)..]
                                        .Split(';')
                                        .Select(part => part.Trim())
                                        .ToArray();


            var subsets = new List<(int Red, int Green, int Blue)>();
            
            
            foreach (var part in parts)
            {
                int red = ExtractNumberByColor(part, "red");
                int green = ExtractNumberByColor(part, "green");
                int blue = ExtractNumberByColor(part, "blue");
                
                subsets.Add((red,green,blue));
            }

            if (subsets.All(subset => subset is { Red: <= 12, Green: <= 13, Blue: <= 14 }))
            {
                total += gameNumber;
            }
            
        }

        // return sum.ToString();
        return total.ToString();
    }
    
    static int ExtractNumberByColor(string inputString, string targetColor)
    {
        // Define the regular expression pattern
        string pattern = $@"(\d+) {targetColor}";

        // Create a Regex object with the pattern
        Regex regex = new Regex(pattern);

        // Match the pattern in the input string
        Match match = regex.Match(inputString);

        // Check if the pattern is found
        if (match.Success)
        {
            // Extract the number from the matched group
            string numberString = match.Groups[1].Value;

            // Parse the number string to an integer
            if (int.TryParse(numberString, out int result))
            {
                return result;
            }
            
        }

        return 0; // Default value if extraction fails
    }

    public override ValueTask<string> Solve_2() => new(Sol2());
    
    private string Sol2()
    {
        var strReader = new StringReader(_input);

        int total = 0;
        while(true)
        {
            var aLine = strReader.ReadLine();
            if (aLine == null)
            {
                break;
            }

            var parts = aLine[(aLine.IndexOf(':') + 2)..]
                .Split(';')
                .Select(part => part.Trim())
                .ToArray();

            var subsets = new List<(int Red, int Green, int Blue)>();
            
            foreach (var part in parts)
            {
                int red = ExtractNumberByColor(part, "red");
                int green = ExtractNumberByColor(part, "green");
                int blue = ExtractNumberByColor(part, "blue");
                
                subsets.Add((red , green , blue ));
            }

            int minRed = subsets.Max(s => s.Red);
            int minGreen = subsets.Max(s => s.Green);
            int minBlue = subsets.Max(s => s.Blue);

            total += minRed * minGreen * minBlue;
        }

        // return sum.ToString();
        return total.ToString();
    }
    
}