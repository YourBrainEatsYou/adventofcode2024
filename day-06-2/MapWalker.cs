using System;

namespace day_06_2;

public class MapWalker
{
  private HashSet<string> _visittedLocations = [];
  private readonly int[,] _map;

  private int[] _currentLocation = new int[2];

  // ^ 0
  // > 1
  // ⌄ 2
  // < 3
  private int[,] _direction = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };

  private int _facingDirection = 0;

  public MapWalker(int[,] map, int[] startingLocation)
  {
    _map = map;
    _currentLocation = startingLocation;

    _visittedLocations.Add($"{_map[_currentLocation[1], _currentLocation[0]]}-{_facingDirection}");
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

  private bool IsOnNewPath()
  {
    int[] target = TargetCoordinates();

    return !_visittedLocations.Contains($"{_map[target[1], target[0]]}-{_facingDirection}");
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

  // returns true if loop detected
  public bool TraverseMap()
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
      if (!_visittedLocations.Add($"{_map[_currentLocation[1], _currentLocation[0]]}-{_facingDirection}"))
      {
        // path was visited
        break;
      }
    }

    return IsInBound();
  }
}
