using System;
using AocUtilities;

namespace day_02_1;

public class Day_02_1 : Day
{
  public Day_02_1() : base("input.txt", 1)
  {
  }

  private static bool IsIncreasing(int[] inputList)
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
