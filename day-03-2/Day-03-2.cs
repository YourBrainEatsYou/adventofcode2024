using System;
using System.Text.RegularExpressions;
using AocUtilities;

namespace day_03_2;

class Day_03_2 : Day
{
  public Day_03_2() : base("input.txt", 2)
  {
  }

  protected override int Solve()
  {
    string pattern = @"(?<activator>do(?:n't)?\(\))|mul\((?<factor1>[\d]+),(?<factor2>[\d]+)\)";
    RegexOptions options = RegexOptions.Multiline;

    int result = 0;
    bool activated = true;

    foreach (Match match in Regex.Matches(Content, pattern, options))
    {
      if (match.Groups["activator"].Value != "")
      {
        activated = match.Groups["activator"].Value == "do()";
      }

      if (activated
        && match.Groups["factor1"].Value != ""
        && match.Groups["factor2"].Value != "")
      {
        result += int.Parse(match.Groups["factor1"].Value) * int.Parse(match.Groups["factor2"].Value);
      }
    }

    return result;
  }
}
