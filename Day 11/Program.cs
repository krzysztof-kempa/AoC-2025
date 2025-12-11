//--- Day 11: Reactor ---
//var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

//var devices = new Dictionary<string, HashSet<string>>();
//var counts = new Dictionary<string, long>();

//foreach (var line in inputLines)
//{
//    var labels = line.Split([' ', ':'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
//    devices[labels.First()] = [.. labels.Skip(1)];
//}

//Console.WriteLine(Search("you"));
//return;

//long Search(string node)
//{
//    long count = 0;

//    foreach (var device in devices[node])
//    {
//        if (device == "out")
//        {
//            count++;
//        }
//        else
//        {
//            if (counts.TryGetValue(device, out var cached))
//            {
//                count += cached;
//            }
//            else
//            {
//                count += Search(device);
//            }
//        }
//    }

//    counts[node] = count;

//    return count;
//}

//--- Part Two ---
var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

var devices = new Dictionary<string, HashSet<string>>();
var counts = new Dictionary<(string node, bool dac, bool fft), long>();

foreach (var line in inputLines)
{
    var labels = line.Split([' ', ':'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    devices[labels.First()] = [.. labels.Skip(1)];
}

Console.WriteLine(Search("svr", false, false));
return;

long Search(string node, bool dac, bool fft)
{
    long count = 0;

    switch (node)
    {
        case "dac":
            dac = true;
            break;
        case "fft":
            fft = true;
            break;
    }

    foreach (var device in devices[node])
    {
        if (device == "out")
        {
            if (dac && fft)
            {
                count++;
            }
        }
        else
        {
            if (counts.TryGetValue((device, dac, fft), out var cached))
            {
                count += cached;
            }
            else
            {
                count += Search(device, dac, fft);
            }
        }
    }

    counts[(node, dac, fft)] = count;

    return count;
}
