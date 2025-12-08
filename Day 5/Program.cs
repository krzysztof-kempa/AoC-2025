//--- Day 5: Cafeteria ---
//var input = File.ReadAllText(@"..\..\..\Input.txt").Split("\r\n\r\n");

//List<(long Start, long End)> ranges = input[0].Split("\r\n").Select(line =>
//{
//    var parts = line.Split('-');
//    return (long.Parse(parts[0]), long.Parse(parts[1]));
//}).ToList();

//var ids = input[1].Split('\n').Select(long.Parse).ToList();

//var count = ids.LongCount(id => ranges.Any(range => id >= range.Start && id <= range.End));

//Console.WriteLine(count);

//--- Part Two ---
var input = File.ReadAllText(@"..\..\..\Input.txt").Split("\r\n\r\n");

List<(long Start, long End)> ranges = input[0].Split("\r\n").Select(line =>
{
    var parts = line.Split('-');
    return (long.Parse(parts[0]), long.Parse(parts[1]));
}).ToList();

ranges = ranges.OrderBy(r => r.Start).ToList();

long count = 0;
var currentStart = ranges[0].Start;
var currentEnd = ranges[0].End;

foreach (var (start, end) in ranges.Skip(1))
{
    if (start <= currentEnd + 1)
    {
        currentEnd = Math.Max(currentEnd, end);
    }
    else
    {
        count += currentEnd - currentStart + 1;
        currentStart = start;
        currentEnd = end;
    }
}

count += currentEnd - currentStart + 1;

Console.WriteLine(count);
