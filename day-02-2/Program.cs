using System.Diagnostics;

using StreamReader reader = new("input.txt");
string[] lines = reader.ReadToEnd().Split('\n', StringSplitOptions.RemoveEmptyEntries);


bool isValidDifference(int[] inputList)
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

bool isIncreasing(int[] inputList)
{
  if (isValidDifference(inputList))
  {
    return true;
  }

  for (int i = 0; i < inputList.Length; i += 1)
  {
    var dampenedListStart = new ArraySegment<int>(inputList, 0, i);
    var dampenedListEnd = new ArraySegment<int>(inputList, i + 1, inputList.Length - 1 - i);

    int[] dampenedList = [.. dampenedListStart, .. dampenedListEnd];

    if (isValidDifference(dampenedList))
    {
      return true;
    }
  }
  return false;
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

Console.WriteLine("Challenge 02: {0} | took {1}ms to compute", result, stopwatch.ElapsedMilliseconds);
