using System.Text.RegularExpressions;
using AocUtilities;

namespace day_03_1;

public class Day_03_1 : Day
{
  public Day_03_1() : base("input.txt", 1)
  {
  }

  protected override int Solve()
  {
    string pattern = @"mul\(([0-9]+),([0-9]+)\)";
    RegexOptions options = RegexOptions.Multiline;

    int result = 0;

    foreach (Match match in Regex.Matches(Content, pattern, options))
    {
      result += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
    }

    return result;
  }
}
