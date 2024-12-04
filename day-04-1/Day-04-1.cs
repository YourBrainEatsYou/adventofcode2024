using AocUtilities;

namespace day_04_1;

public class Day_04_1 : Day
{
  private readonly char[] _charList = ['X', 'M', 'A', 'S'];

  private readonly int[][] _directions = [[1, 0], [1, 1], [0, 1], [-1, 1], [-1, 0], [-1, -1], [0, -1], [1, -1]];

  private readonly char[][] _input;

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

  private bool IsWordPossible(int[] direction, int[] coordinates, int wordLength)
  {
    int xAxisDestination = direction[0] * wordLength;
    int yAxisDestination = direction[1] * wordLength;

    // check if its possible
    return Enumerable.Range(-1, _input.Length + 2).Contains(coordinates[0] + xAxisDestination) &&
    Enumerable.Range(-1, _input[coordinates[0]].Length + 2).Contains(coordinates[1] + yAxisDestination);
  }

  private bool CheckForChar(int[] direction, int[] coordinates, int charListIndex = 0)
  {
    if (!IsWordPossible(direction, coordinates, _charList.Length - charListIndex))
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
    return CheckForChar(
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
        if (_input[yAxis][xAxis] == _charList[0])
        {
          foreach (int[] direction in _directions)
          {
            result += CheckForChar(direction, [xAxis, yAxis]) ? 1 : 0;
          }
        }
      }
    }

    return result;
  }
}
