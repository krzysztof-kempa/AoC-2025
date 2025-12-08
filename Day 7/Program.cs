//--- Day 7: Laboratories ---
//var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

//var maxY = inputLines.Length;
//var maxX = inputLines[0].Length;

//var diagram = new char[maxY][];

//for (var y = 0; y < maxY; y++)
//{
//    diagram[y] = new char[maxX];

//    for (var x = 0; x < maxX; x++)
//    {
//        diagram[y][x] = inputLines[y][x];
//        Console.Write(diagram[y][x]);
//    }
//    Console.WriteLine();
//}
//Console.WriteLine();

//var totalSplits = 0;

//for (var y = 1; y < maxY; y++)
//{
//    for (var x = 0; x < maxX; x++)
//    {
//        if (diagram[y - 1][x] == '|' || diagram[y - 1][x] == 'S')
//        {
//            if (diagram[y][x] == '.')
//            {
//                diagram[y][x] = '|';
//            }
//            else if (diagram[y][x] == '^')
//            {
//                totalSplits++;

//                if (x > 0)
//                {
//                    diagram[y][x - 1] = '|';
//                }

//                if (x < maxX - 1)
//                {
//                    diagram[y][x + 1] = '|';
//                }
//            }
//        }
//    }
//}

//for (var y = 0; y < maxY; y++)
//{
//    for (var x = 0; x < maxX; x++)
//    {
//        Console.Write(diagram[y][x]);
//    }
//    Console.WriteLine();
//}
//Console.WriteLine();

//Console.WriteLine(totalSplits);

//--- Part Two ---
var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

var maxY = inputLines.Length;
var maxX = inputLines[0].Length;

var diagram = new char[maxY][];

for (var y = 0; y < maxY; y++)
{
    diagram[y] = new char[maxX];

    for (var x = 0; x < maxX; x++)
    {
        diagram[y][x] = inputLines[y][x];
    }
}

var currentCounts = new long[maxX];

for (var y = 0; y < maxY; y++)
{
    var previousCounts = (long[])currentCounts.Clone();
    currentCounts = new long[maxX];

    for (var x = 0; x < maxX; x++)
    {
        if (diagram[y][x] == 'S')
        {
            currentCounts[x] = 1;
        }
        else if (previousCounts[x] > 0)
        {
            if (diagram[y][x] == '.')
            {
                currentCounts[x] += previousCounts[x];
            }
            else if (diagram[y][x] == '^')
            {
                if (x > 0)
                {
                    currentCounts[x - 1] += previousCounts[x];
                }

                if (x < maxX - 1)
                {
                    currentCounts[x + 1] += previousCounts[x];
                }
            }
        }
    }
}

var timelineCount = currentCounts.Sum();

Console.WriteLine(timelineCount);
