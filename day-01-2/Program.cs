using System.Diagnostics;
using System.Timers;

using StreamReader reader = new("input.txt");
string[] inputLines = reader.ReadToEnd().Split('\n', StringSplitOptions.RemoveEmptyEntries);

int[] inputLeft = new int[inputLines.Length];
int[] inputRight = new int[inputLines.Length];

for (int i = 0; i < inputLines.Length; i += 1)
{
  string[] lineArgs = inputLines[i].Split("   ");

  inputLeft[i] = Int32.Parse(lineArgs[0]);
  inputRight[i] = Int32.Parse(lineArgs[1]);
}


// create dictionary for left side
Dictionary<int, int> appearance = [];

foreach (int right in inputRight)
{
  if (appearance.TryGetValue(right, out int currentValue))
  {
    appearance[right] = currentValue + 1;
  }
  else
  {
    appearance.Add(right, 1);
  }
}



int solve()
{
  int result = 0;

  foreach (int left in inputLeft)
  {
    appearance.TryGetValue(left, out int multiplier);

    result += left * multiplier;
  }
  return result;
}

Stopwatch stopwatch = new();

stopwatch.Start();
int result = solve();
stopwatch.Stop();

Console.WriteLine("Challenge 02: {0} | took {1}ms to compute", result, (double)stopwatch.ElapsedTicks / 100_000);

