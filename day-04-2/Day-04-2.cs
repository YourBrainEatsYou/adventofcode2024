using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AocUtilities;

namespace day_04_2;

public class Day_04_2 : Day
{
  private char[][] _input;

  private char[][] _possibilities = [['M', 'S'], ['S', 'M']];

  private int[][,] _locations = [new int[,] { { -1, -1 }, { 1, 1 } }, new int[,] { { 1, -1 }, { -1, 1 } }];

  public Day_04_2() : base("input.txt", 2)
  {
    _input = new char[Lines.Length][];

    for (int i = 0; i < Lines.Length; i++)
    {
      for (int j = 0; j < Lines[i].Length; j++)
      {
        _input[i] = Lines[i].ToCharArray();
      }
    }
  }

  private bool MatchesCharsAtLocations(int[] coordinates, int[,] location)
  {
    char target1 = _input[coordinates[1] + location[0, 1]][coordinates[0] + location[0, 0]];
    char target2 = _input[coordinates[1] + location[1, 1]][coordinates[0] + location[1, 0]];

    if (
      target1 == _possibilities[0][0] && target2 == _possibilities[0][1]
      || target1 == _possibilities[1][0] && target2 == _possibilities[1][1]
    )
    {
      return true;
    }

    return false;
  }

  private bool CheckForCross(int[] coordinates)
  {
    foreach (int[,] location in _locations)
    {
      if (!MatchesCharsAtLocations(coordinates, location))
      {
        return false;
      }
    }

    return true;

  }

  protected override int Solve()
  {
    int result = 0;

    // ignore first and last line
    for (int yAxis = 1; yAxis < _input.Length - 1; yAxis++)
    {
      // ignore first and last col
      for (int xAxis = 1; xAxis < _input[yAxis].Length - 1; xAxis++)
      {
        // has found an A
        if (_input[yAxis][xAxis] == 'A')
        {
          result += CheckForCross([xAxis, yAxis]) ? 1 : 0;
        }
      }
    }

    return result;
  }
}
