using System;
using AocUtilities;
namespace day_05_2;

public class Day_05_2 : Day
{
  private readonly int[][] _rules;
  private readonly int[][] _manuals;

  public Day_05_2() : base("input.txt", 2)
  {
    // prepare arrays
    string[] content = Content.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

    string[] rules = content[0].Split("\n", StringSplitOptions.RemoveEmptyEntries);

    _rules = new int[rules.Length][];

    for (int i = 0; i < rules.Length; i++)
    {
      int[] rule = rules[i].Split('|', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

      _rules[i] = rule;
    }

    string[] manuals = content[1].Split("\n", StringSplitOptions.RemoveEmptyEntries);

    _manuals = new int[manuals.Length][];

    for (int i = 0; i < manuals.Length; i++)
    {
      _manuals[i] = manuals[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    }
  }

  private bool ValidateManual(int[] manual)
  {
    foreach (int[] rule in _rules)
    {
      int iLeft = Array.IndexOf(manual, rule[0]);
      int iRight = Array.IndexOf(manual, rule[1]);

      if (iLeft < 0 || iRight < 0)
      {
        continue;
      }

      if (iLeft > iRight)
      {
        return false;
      }
    }

    return true;
  }


  private int[] FixedManual(int[] manual)
  {

    List<int> manualList = new();
    manualList.AddRange(manual);

    while (!ValidateManual(manualList.ToArray()))
    {
      foreach (int[] rule in _rules)
      {
        int iLeft = manualList.IndexOf(rule[0]);
        int iRight = manualList.IndexOf(rule[1]);

        if (iLeft < 0 || iRight < 0)
        {
          continue;
        }

        if (iLeft > iRight)
        {
          int poppedItem = manualList[iLeft];
          manualList.RemoveAt(iLeft);
          manualList.Insert(iRight, poppedItem);
        }
      }
    }

    return manualList.ToArray();
  }

  protected override int Solve()
  {
    int result = 0;

    for (int i = 0; i < _manuals.Length; i++)
    {
      if (ValidateManual(_manuals[i]))
      {
        continue;
      }

      result += FixedManual(_manuals[i])[(_manuals[i].Length - 1) / 2];
    }
    foreach (int[] manual in _manuals)
    {

    }

    return result;
  }
}
