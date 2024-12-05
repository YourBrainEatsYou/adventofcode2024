using System;
using System.Transactions;
using AocUtilities;

namespace day_05_1;

public class Day_05_1 : Day
{
  private readonly int[][] _rules;
  private readonly int[][] _manuals;

  public Day_05_1() : base("input.txt", 1)
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

  protected override int Solve()
  {
    int result = 0;

    for (int i = 0; i < _manuals.Length; i++)
    {
      if (ValidateManual(_manuals[i]))
      {
        //Console.WriteLine("Index: {0}, Middle: {1}", i, _manuals[i][(_manuals[i].Length - 1) / 2]);
        result += _manuals[i][(_manuals[i].Length - 1) / 2];
      }
    }
    foreach (int[] manual in _manuals)
    {

    }

    return result;
  }
}
