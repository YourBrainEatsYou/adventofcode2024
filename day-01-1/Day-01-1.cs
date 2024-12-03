using AocUtilities;

namespace day_01_1;

public class Day_01_1 : Day
{
  private readonly int[] _inputLeft;
  private readonly int[] _inputRight;


  public Day_01_1() : base("input.txt", 1)
  {
    _inputLeft = new int[Lines.Length];
    _inputRight = new int[Lines.Length];

    for (int i = 0; i < Lines.Length; i += 1)
    {
      string[] lineArgs = Lines[i].Split("   ");

      _inputLeft[i] = int.Parse(lineArgs[0]);
      _inputRight[i] = int.Parse(lineArgs[1]);
    }
  }

  protected override int Solve()
  {
    // sort inputs
    Array.Sort(_inputLeft);
    Array.Sort(_inputRight);

    int result = 0;
    for (int j = 0; j < _inputLeft.Length; j += 1)
    {
      result += Math.Abs(_inputLeft[j] - _inputRight[j]);
    }
    return result;
  }
}
