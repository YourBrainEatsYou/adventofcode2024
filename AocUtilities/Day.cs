using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AocUtilities;

public abstract class Day
{
  private readonly string _content;

  protected Stopwatch stopwatch = new();

  private int _result;
  private readonly int _challenge;

  public Day(string file = "input.txt", int challenge = 1)
  {
    stopwatch.Start();
    _challenge = challenge;
    using StreamReader reader = new(file);
    _content = reader.ReadToEnd();
  }

  protected string Content
  {
    get => _content;
  }

  protected string[] Lines
  {
    get => _content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
  }

  protected abstract int Solve();

  public void Result([CallerMemberName] string caller = "")
  {
    _result = Solve();
    stopwatch.Stop();

    Console.WriteLine("Challenge 0{0}: {1} | took {2}ms to compute", _challenge, _result, stopwatch.ElapsedMilliseconds);
  }
}
