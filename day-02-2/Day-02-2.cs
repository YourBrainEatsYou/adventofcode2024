using System;
using AocUtilities;

namespace day_02_2;

public class Day_02_2 : Day
{
  public Day_02_2() : base("input.txt", 2)
  {
  }

  private static bool IsValidDifference(int[] inputList)
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

  private static bool IsIncreasing(int[] inputList)
  {
    if (IsValidDifference(inputList))
    {
      return true;
    }

    for (int i = 0; i < inputList.Length; i += 1)
    {
      var dampenedListStart = new ArraySegment<int>(inputList, 0, i);
      var dampenedListEnd = new ArraySegment<int>(inputList, i + 1, inputList.Length - 1 - i);

      int[] dampenedList = [.. dampenedListStart, .. dampenedListEnd];

      if (IsValidDifference(dampenedList))
      {
        return true;
      }
    }
    return false;
  }

  private static bool IsDecreasing(int[] inputList)
  {
    return IsIncreasing(inputList.Reverse().ToArray());
  }

  private static bool IsSave(int[] inputList)
  {
    return IsIncreasing(inputList) || IsDecreasing(inputList);
  }

  protected override int Solve()
  {
    int result = 0;
    foreach (string line in Lines)
    {
      int[] inputArray = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
      .Select(int.Parse)
      .ToArray();

      result += IsSave(inputArray) ? 1 : 0;
    }

    return result;
  }
}
