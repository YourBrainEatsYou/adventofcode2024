using System.Diagnostics;

string[] lines = new LineReader("input.txt").Lines;

bool isIncreasing(int[] inputList)
{
  for (int i = 1; i < inputList.Length; i += 1)
  {
    // check if is higher than previous item
    int difference = inputList[i] - inputList[i - 1];
    if (!Enumerable.Range(1, 3).Contains(difference))
    {
      return false;
    }
  }

  return true;
}

bool isDecreasing(int[] inputList)
{
  return isIncreasing(inputList.Reverse().ToArray());
}

bool isSave(int[] inputList)
{
  return isIncreasing(inputList) || isDecreasing(inputList);
}

int solve()
{
  int result = 0;
  foreach (string line in lines)
  {
    int[] inputArray = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

    result += isSave(inputArray) ? 1 : 0;
  }

  return result;
}

Stopwatch stopwatch = new();

stopwatch.Start();
int result = solve();
stopwatch.Stop();

Console.WriteLine("Challenge 01: {0} | took {1}ms to compute", result, stopwatch.ElapsedMilliseconds);
