using AocUtilities;

namespace day_06_2;

public class Day_06_2 : Day
{
  private HashSet<string> _visittedLocations = [];
  private readonly int[,] _map;

  private int[] _currentLocation = new int[2];

  // ^ 0
  // > 1
  // ⌄ 2
  // < 3
  private int[,] _direction = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };

  public Day_06_2() : base("input.txt", 2)
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
        _visittedLocations.Add($"{_map[yAxis, xAxis]}-{_direction}");
        continue;
      }
    }
  }

  private static int GetIdFromCoordinates(int x, int y, int width)
  {
    return (y * width) + x + 1;
  }

  protected override int Solve()
  {
    int result = 0;

    int yLength = _map.GetLength(0);
    int xLength = _map.GetLength(1);


    for (int yCoord = 0; yCoord < yLength; yCoord += 1)
    {
      for (int xCoord = 0; xCoord < xLength; xCoord += 1)
      {
        if (_map[yCoord, xCoord] == 0 || (yCoord == _currentLocation[1] && xCoord == _currentLocation[0]))
        {
          continue;
        }

        var mapClone = _map.Clone();

        if (mapClone is int[,] map)
        {
          // manipulate map
          map[yCoord, xCoord] = 0;

          MapWalker mapWalker = new(map, _currentLocation);
          result += mapWalker.TraverseMap() ? 1 : 0;
        }
      }
    }


    return result;
  }
}
