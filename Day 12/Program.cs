//--- Day 12: Christmas Tree Farm ---
var input = File.ReadAllText(@"..\..\..\Input.txt");

var blocks = input.Split("\r\n\r\n");

var shapes = new int[6];

for (var i = 0; i < 6; i++)
{
    var block = blocks[..^1][i];
    shapes[i] = block.Count(c => c == '#');
}

var sections = blocks[^1].Split("\r\n").Select(s => s.Split(": ")).ToArray();

var regions = 0;

foreach (var section in sections)
{
    var covered = 0;

    var required = section[1].Split(' ').Select(int.Parse).ToArray();

    var area = section[0].Split('x').Select(int.Parse).Aggregate(1, (a, b) => a * b);

    for (var i = 0; i < 6; i++)
    {
        covered += required[i] * shapes[i];
    }

    if (covered <= area)
    {
        regions++;
    }
}

Console.WriteLine(regions);
