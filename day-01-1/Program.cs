using System.Diagnostics;

using StreamReader reader = new("input.txt");

string[] input = reader.ReadToEnd().Split('\n');
string[] inputLines = input.Take(input.Length - 1).ToArray();

int[] inputLeft = new int[inputLines.Length];
int[] inputRight = new int[inputLines.Length];

for (int i = 0; i < inputLines.Length; i += 1)
{
  string[] lineArgs = inputLines[i].Split("   ");

  inputLeft[i] = Int32.Parse(lineArgs[0]);
  inputRight[i] = Int32.Parse(lineArgs[1]);
}

// sort inputs
Array.Sort(inputLeft);
Array.Sort(inputRight);

int solve()
{
  int result = 0;
  for (int j = 0; j < inputLeft.Length; j += 1)
  {
    result += Math.Abs(inputLeft[j] - inputRight[j]);
  }
  return result;
}


Stopwatch stopwatch = new();
stopwatch.Start();
int result = solve();
stopwatch.Stop();

Console.WriteLine("Challenge 01: {0} | took {1}ms to compute", result, (double)stopwatch.ElapsedTicks / 100_000);


