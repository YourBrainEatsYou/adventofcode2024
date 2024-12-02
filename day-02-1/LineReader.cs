class LineReader
{

  private string[] _inputLines;

  public LineReader(string inputStream)
  {
    using StreamReader reader = new(inputStream);

    string[] input = reader.ReadToEnd().Split('\n');
    _inputLines = input.Take(input.Length - 1).ToArray();
  }

  public string[] Lines
  {
    get => _inputLines;
  }
}
