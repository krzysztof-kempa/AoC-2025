//--- Day 9: Movie Theater ---
//var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

//var tiles = inputLines
//    .Select(line =>
//    {
//        var p = line.Split(',');
//        return (X: long.Parse(p[0]), Y: long.Parse(p[1]));
//    })
//    .ToArray();

//var maxArea = 0L;

//for (var i = 0; i < tiles.Length; i++)
//{
//    for (var j = i + 1; j < tiles.Length; j++)
//    {
//        var width = tiles[i].X - tiles[j].X >= 0 ? tiles[i].X - tiles[j].X + 1 : tiles[j].X - tiles[i].X + 1;
//        var height = tiles[i].Y - tiles[j].Y >= 0 ? tiles[i].Y - tiles[j].Y + 1 : tiles[j].Y - tiles[i].Y + 1;

//        var area = width * height;

//        if (area > maxArea)
//        {
//            maxArea = area;
//        }
//    }
//}

//Console.WriteLine(maxArea);

//--- Part Two ---
var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

var tiles = inputLines
    .Select(line =>
    {
        var p = line.Split(',');
        return (X: long.Parse(p[0]), Y: long.Parse(p[1]));
    })
    .ToArray();

var edges = new List<Edge>();

for (var i = 0; i < tiles.Length; i++)
{
    var next = (i + 1) % tiles.Length;
    edges.Add(new Edge(tiles[i], tiles[next]));
}

long maxArea = 0;

for (var i = 0; i < tiles.Length; i++)
{
    for (var j = i + 1; j < tiles.Length; j++)
    {
        var x1 = Math.Min(tiles[i].X, tiles[j].X);
        var x2 = Math.Max(tiles[i].X, tiles[j].X);
        var y1 = Math.Min(tiles[i].Y, tiles[j].Y);
        var y2 = Math.Max(tiles[i].Y, tiles[j].Y);

        var area = (x2 - x1 + 1) * (y2 - y1 + 1);

        if (area <= maxArea)
        {
            continue;
        }

        var valid = true;

        foreach (var edge in edges)
        {
            if (edge.IsVertical)
            {
                var startX = edge.Start.X;

                if (startX > x1 && startX < x2)
                {
                    var yMin = Math.Min(edge.Start.Y, edge.End.Y);
                    var yMax = Math.Max(edge.Start.Y, edge.End.Y);

                    if (Math.Max(y1, yMin) < Math.Min(y2, yMax))
                    {
                        valid = false;
                        break;
                    }
                }
            }
            else
            {
                var startY = edge.Start.Y;
                if (startY > y1 && startY < y2)
                {
                    var xMin = Math.Min(edge.Start.X, edge.End.X);
                    var xMax = Math.Max(edge.Start.X, edge.End.X);

                    if (Math.Max(x1, xMin) < Math.Min(x2, xMax))
                    {
                        valid = false;
                        break;
                    }
                }
            }
        }

        if (valid)
        {
            maxArea = area;
        }
    }
}

Console.WriteLine(maxArea);

public class Edge((long X, long Y) start, (long X, long Y) end)
{
    public (long X, long Y) Start = start;
    public (long X, long Y) End = end;

    public bool IsVertical => Start.X == End.X;
}
