using System;
using AocUtilities;

namespace day_01_2;

public class Day_01_2 : Day
{
  private readonly int[] _inputLeft;
  private readonly int[] _inputRight;

  private readonly Dictionary<int, int> _appearance = [];

  public Day_01_2() : base("input.txt", 2)
  {
    _inputLeft = new int[Lines.Length];
    _inputRight = new int[Lines.Length];

    for (int i = 0; i < Lines.Length; i += 1)
    {
      string[] lineArgs = Lines[i].Split("   ");

      _inputLeft[i] = int.Parse(lineArgs[0]);
      _inputRight[i] = int.Parse(lineArgs[1]);
    }

    foreach (int right in _inputRight)
    {
      if (_appearance.TryGetValue(right, out int currentValue))
      {
        _appearance[right] = currentValue + 1;
      }
      else
      {
        _appearance.Add(right, 1);
      }
    }
  }

  protected override int Solve()
  {
    int result = 0;

    foreach (int left in _inputLeft)
    {
      _appearance.TryGetValue(left, out int multiplier);

      result += left * multiplier;
    }
    return result;
  }
}
