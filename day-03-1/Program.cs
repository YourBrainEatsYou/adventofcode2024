using System.Diagnostics;
using System.Text.RegularExpressions;

using StreamReader reader = new("input.txt");
string text = reader.ReadToEnd();

string pattern = @"mul\(([0-9]+),([0-9]+)\)";
RegexOptions options = RegexOptions.Multiline;

int solve()
{
  int result = 0;

  foreach (Match match in Regex.Matches(text, pattern, options))
  {
    result += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
  }

  return result;
}

Stopwatch stopwatch = new();

stopwatch.Start();
int result = solve();
stopwatch.Stop();

Console.WriteLine("Challenge 01: {0} | took {1}ms to compute", result, stopwatch.ElapsedMilliseconds);
