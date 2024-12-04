using AocUtilities;

namespace day_04_1;

public class Day_04_1 : Day
{
  private char[] _charList = ['X', 'M', 'A', 'S'];

  private int[][] _directions = [[1, 0], [1, 1], [0, 1], [-1, 1], [-1, 0], [-1, -1], [0, -1], [1, -1]];

  private char[][] _input;

  public Day_04_1() : base("input.txt", 1)
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

  private bool checkForCharList(int[] direction, int[] coordinates, int charListIndex = 0)
  {
    int xAxisDestination = direction[0] * (_charList.Length - charListIndex);
    int yAxisDestination = direction[1] * (_charList.Length - charListIndex);

    // check if its possible
    if (
      !Enumerable.Range(-1, _input.Length + 2).Contains(coordinates[0] + xAxisDestination)
      || !Enumerable.Range(-1, _input[coordinates[0]].Length + 2).Contains(coordinates[1] + yAxisDestination))
    {
      return false;
    }

    // char ist not in searched list so return false
    if (_input[coordinates[1]][coordinates[0]] != _charList[charListIndex])
    {
      return false;
    }

    // if it was the last char, congrats theres XMAS
    if (charListIndex == _charList.Length - 1)
    {
      return true;
    }

    // prepare next run
    return checkForCharList(
      direction,
      [
        coordinates[0] + direction[0],
        coordinates[1] + direction[1]
      ],
      charListIndex + 1
    );
  }


  protected override int Solve()
  {
    int result = 0;

    for (int yAxis = 0; yAxis < _input.Length; yAxis++)
    {
      for (int xAxis = 0; xAxis < _input[yAxis].Length; xAxis++)
      {
        // if is X
        if (_input[yAxis][xAxis] == _charList[0])
        {
          foreach (int[] direction in _directions)
          {
            result += checkForCharList(direction, [xAxis, yAxis]) ? 1 : 0;
          }
        }
      }
    }

    return result;
  }
}
