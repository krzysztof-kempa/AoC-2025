//--- Day 4: Printing Department ---
//var map = File.ReadAllLines(@"..\..\..\Input.txt");

//var maxY = map.Length;
//var maxX = map[0].Length;

//for (var y = 0; y < maxY; y++)
//{
//    for (var x = 0; x < maxX; x++)
//    {
//        Console.Write(map[y][x]);
//    }

//    Console.WriteLine();
//}

//Console.WriteLine();

//var accessibleRolls = 0;

//for (var y = 0; y < maxY; y++)
//{
//    for (var x = 0; x < maxX; x++)
//    {
//        if (map[y][x] != '@')
//        {
//            Console.Write(map[y][x]);
//            continue;
//        }

//        var count = 0;

//        foreach (var (diffY, diffX) in new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) })
//        {
//            if (y + diffY < 0 || y + diffY >= maxY || x + diffX < 0 || x + diffX >= maxX)
//            {
//                continue;
//            }

//            if (map[y + diffY][x + diffX] == '@')
//            {
//                count++;
//            }
//        }

//        if (count < 4)
//        {
//            accessibleRolls++;
//            Console.Write('x');
//        }
//        else
//        {
//            Console.Write(map[y][x]);
//        }
//    }

//    Console.WriteLine();
//}

//Console.WriteLine(accessibleRolls);

//--- Part Two ---
var input = File.ReadAllLines(@"..\..\..\Input.txt");

var maxY = input.Length;
var maxX = input[0].Length;

var map = new char[maxY][];

for (var y = 0; y < maxY; y++)
{
    map[y] = new char[maxX];

    for (var x = 0; x < maxX; x++)
    {
        map[y][x] = input[y][x];
    }
}

var rolls = new List<(int y, int x)>();
var removedRolls = 0;

while (true)
{
    var accessibleRolls = 0;

    for (var y = 0; y < maxY; y++)
    {
        for (var x = 0; x < maxX; x++)
        {
            if (map[y][x] != '@')
            {
                continue;
            }

            var count = 0;

            foreach (var (diffY, diffX) in new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) })
            {
                if (y + diffY < 0 || y + diffY >= maxY || x + diffX < 0 || x + diffX >= maxX)
                {
                    continue;
                }

                if (map[y + diffY][x + diffX] == '@')
                {
                    count++;
                }
            }

            if (count < 4)
            {
                rolls.Add((y, x));
                accessibleRolls++;
            }
        }
    }

    foreach (var (y, x) in rolls)
    {
        map[y][x] = '.';
    }

    rolls.Clear();

    if (accessibleRolls > 0)
    {
        removedRolls += accessibleRolls;
    }
    else
    {
        break;
    }

    //for (var y = 0; y < maxY; y++)
    //{
    //    for (var x = 0; x < maxX; x++)
    //    {
    //        Console.Write(map[y][x]);
    //    }

    //    Console.WriteLine();
    //}
}

Console.WriteLine(removedRolls);
