//--- Day 8: Playground ---
//var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

//var n = inputLines.Length;

//var points = new (long X, long Y, long Z)[n];

//for (var i = 0; i < n; i++)
//{
//    var parts = inputLines[i].Split(',');

//    points[i] = (long.Parse(parts[0]), long.Parse(parts[1]), long.Parse(parts[2]));
//}

//var edges = new List<(int A, int B, long Distance)>();

//for (var i = 0; i < points.Length; ++i)
//{
//    for (var j = i + 1; j < points.Length; ++j)
//    {
//        var dx = points[i].X - points[j].X;
//        var dy = points[i].Y - points[j].Y;
//        var dz = points[i].Z - points[j].Z;

//        var dist = dx * dx + dy * dy + dz * dz;

//        edges.Add((i, j, dist));
//    }
//}

//edges.Sort((a, b) => a.Distance.CompareTo(b.Distance));

//var unionFind = new UnionFind(n);

//var connections = 0;

//foreach (var e in edges)
//{
//    unionFind.Union(e.A, e.B);

//    connections++;

//    if (connections >= 1000)
//    {
//        break;
//    }
//}

//var counts = new Dictionary<int, int>();

//for (var i = 0; i < n; i++)
//{
//    var root = unionFind.Find(i);

//    counts.TryAdd(root, 0);

//    counts[root]++;
//}

//var largest3 = counts.Values.OrderByDescending(x => x).Take(3).ToArray();

//var result = (long)largest3[0] * largest3[1] * largest3[2];

//Console.WriteLine(result);

//public class UnionFind
//{
//    private readonly int[] _parent;
//    private readonly int[] _size;

//    public UnionFind(int n)
//    {
//        _parent = new int[n];
//        _size = new int[n];

//        for (var i = 0; i < n; i++)
//        {
//            _parent[i] = i;
//            _size[i] = 1;
//        }
//    }

//    public int Find(int x)
//    {
//        if (_parent[x] != x)
//        {
//            _parent[x] = Find(_parent[x]);
//        }

//        return _parent[x];
//    }

//    public void Union(int a, int b)
//    {
//        var ra = Find(a);
//        var rb = Find(b);

//        if (ra == rb)
//        {
//            return;
//        }

//        if (_size[ra] < _size[rb])
//        {
//            _parent[ra] = rb;
//            _size[rb] += _size[ra];
//        }
//        else
//        {
//            _parent[rb] = ra;
//            _size[ra] += _size[rb];
//        }
//    }
//}

//--- Part Two ---
var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

var n = inputLines.Length;

var points = new (long X, long Y, long Z)[n];

for (var i = 0; i < n; i++)
{
    var parts = inputLines[i].Split(',');

    points[i] = (long.Parse(parts[0]), long.Parse(parts[1]), long.Parse(parts[2]));
}

var edges = new List<(int A, int B, long Distance)>();

for (var i = 0; i < points.Length; ++i)
{
    for (var j = i + 1; j < points.Length; ++j)
    {
        var dx = points[i].X - points[j].X;
        var dy = points[i].Y - points[j].Y;
        var dz = points[i].Z - points[j].Z;

        var dist = dx * dx + dy * dy + dz * dz;

        edges.Add((i, j, dist));
    }
}

edges.Sort((a, b) => a.Distance.CompareTo(b.Distance));

var unionFind = new UnionFind(n);

var result = 0L;

foreach (var e in edges)
{
    unionFind.Union(e.A, e.B);

    if (unionFind.AllConnected())
    {
        result = points[e.A].X * points[e.B].X;
        break;
    }
}

Console.WriteLine(result);

public class UnionFind
{
    private readonly int[] _parent;
    private readonly int[] _size;

    public UnionFind(int n)
    {
        _parent = new int[n];
        _size = new int[n];

        for (var i = 0; i < n; i++)
        {
            _parent[i] = i;
            _size[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (_parent[x] != x)
        {
            _parent[x] = Find(_parent[x]);
        }

        return _parent[x];
    }

    public void Union(int a, int b)
    {
        var ra = Find(a);
        var rb = Find(b);

        if (ra == rb)
        {
            return;
        }

        if (_size[ra] < _size[rb])
        {
            _parent[ra] = rb;
            _size[rb] += _size[ra];
        }
        else
        {
            _parent[rb] = ra;
            _size[ra] += _size[rb];
        }
    }

    public bool AllConnected()
    {
        return _parent.Select(Find).ToHashSet().Count == 1;
    }
}
