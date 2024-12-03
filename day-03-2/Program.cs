
using System.Diagnostics;
using System.Text.RegularExpressions;

using StreamReader reader = new("input.txt");
string text = reader.ReadToEnd();

string pattern = @"(?<activator>do(?:n't)?\(\))|mul\((?<factor1>[\d]+),(?<factor2>[\d]+)\)";
RegexOptions options = RegexOptions.Multiline;

int solve()
{
  int result = 0;
  bool activated = true;

  foreach (Match match in Regex.Matches(text, pattern, options))
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

Stopwatch stopwatch = new();

stopwatch.Start();
int result = solve();
stopwatch.Stop();

Console.WriteLine("Challenge 02: {0} | took {1}ms to compute", result, stopwatch.ElapsedMilliseconds);
