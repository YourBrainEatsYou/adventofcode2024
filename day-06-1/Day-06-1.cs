using AocUtilities;

namespace day_06_1;

public class Day_06_1 : Day
{
  private HashSet<int> _visittedLocations = [];
  private readonly int[,] _map;

  private int[] _currentLocation = new int[2];

  // ^ 0
  // > 1
  // ⌄ 2
  // < 3
  private int[,] _direction = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };

  private int _facingDirection = 0;

  public Day_06_1() : base("input.txt", 1)
  {
    _map = new int[Lines.Length, Lines[0].ToCharArray().Length];

    for (int yAxis = 0; yAxis < Lines.Length; yAxis += 1)
    {
      char[] line = Lines[yAxis].ToCharArray();

      for (int xAxis = 0; xAxis < line.Length; xAxis += 1)
      {
        if (line[xAxis] == '.')
        {
          _map[yAxis, xAxis] = GetIdFromCoordinates(xAxis, yAxis, line.Length);
          continue;
        }

        if (line[xAxis] == '#')
        {
          _map[yAxis, xAxis] = 0;
          continue;
        }

        _map[yAxis, xAxis] = GetIdFromCoordinates(xAxis, yAxis, line.Length);

        _currentLocation = [xAxis, yAxis];
        _visittedLocations.Add(_map[yAxis, xAxis]);
        continue;
      }
    }
  }

  private void TurnCW()
  {
    if (_facingDirection + 1 >= _direction.GetLength(0))
    {
      _facingDirection = 0;
      return;
    }
    _facingDirection += 1;
  }

  private int[] TargetCoordinates()
  {
    return [
      _currentLocation[0] + _direction[_facingDirection, 0],
      _currentLocation[1] + _direction[_facingDirection, 1]
    ];
  }

  private bool IsInBound()
  {
    int xLength = _map.GetLength(1);
    int yLength = _map.GetLength(0);

    int[] target = TargetCoordinates();

    return Enumerable.Range(0, xLength).Contains(target[0]) && Enumerable.Range(0, yLength).Contains(target[1]);
  }

  private bool IsPathBlocked()
  {
    int[] target = TargetCoordinates();
    return _map[target[1], target[0]] == 0;
  }

  private void MakeStep()
  {
    _currentLocation = TargetCoordinates();
  }

  private void TraverseMap()
  {
    while (IsInBound())
    {
      // turn CW as long as the current path is blocked
      while (IsPathBlocked())
      {
        TurnCW();
      }

      // make Step
      MakeStep();

      // set current position as visited
      _visittedLocations.Add(_map[_currentLocation[1], _currentLocation[0]]);
    }
  }

  private static int GetIdFromCoordinates(int x, int y, int width)
  {
    return (y * width) + x + 1;
  }

  protected override int Solve()
  {
    TraverseMap();
    return _visittedLocations.Count;
  }
}
