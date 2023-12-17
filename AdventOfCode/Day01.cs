namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new(Sol1());

    private string Sol1()
    {
        var strReader = new StringReader(_input);

        var total = 0;
        while(true)
        {
            var aLine = strReader.ReadLine();
            if(aLine != null)
            {
                var arr = aLine.ToCharArray();

                arr = Array.FindAll<char>(arr, (c => (char.IsNumber(c))));

                if (arr.Length == 0)
                {
                    continue;
                }
                total += int.Parse($"{arr[0]}{arr[^1]}");
            }
            else
            {
               break;
            }
        }

        return total.ToString();
    }
    
    public override ValueTask<string> Solve_2() => new(Sol2());

    private string Sol2()
    {
        var strReader = new StringReader(_input);

        var total = 0;
        while(true)
        {
            var aLine = strReader.ReadLine();
            if(aLine != null)
            {
                var arr = ReplaceNumbStrings(aLine).ToCharArray();

                arr = Array.FindAll<char>(arr, (c => (char.IsNumber(c))));

                total += int.Parse($"{arr[0]}{arr[^1]}");
            }
            else
            {
                break;
            }
        }

        return total.ToString();
    }

    private string ReplaceNumbStrings(string line)
    {
        var bla = string.Empty;
        for (int i = 0; i < line.Length; i++)
        {
            if (!char.IsNumber(line[i]))
            {
                for (int j = 0; j < _numbs.Length; j++)
                {
                    if (line.Substring(i).StartsWith(_numbs[j]))
                    {
                        bla += (j + 1).ToString();
                    }
                }
            }
            else
            {
                bla += line[i];
                
            }
        }
        
        return bla;
    }
    
    private readonly string[] _numbs = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
}
