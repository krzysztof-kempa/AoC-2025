//--- Day 3: Lobby ---
//var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

//var banksCount = inputLines.Length;
//var batteriesCount = inputLines[0].Length;

//var banks = new int[banksCount][];

//for (var i = 0; i < banksCount; i++)
//{
//    banks[i] = new int[batteriesCount];

//    for (var j = 0; j < batteriesCount; j++)
//    {
//        banks[i][j] = inputLines[i][j] - '0';
//    }
//}

//var joltage = 0;

//for (var i = 0; i < banksCount; i++)
//{
//    var firstMax = banks[i][0];
//    var firstMaxPos = 0;

//    for (var j = 1; j < batteriesCount - 1; j++)
//    {
//        if (banks[i][j] > firstMax)
//        {
//            firstMax = banks[i][j];
//            firstMaxPos = j;
//        }
//    }

//    var secondMax = 0;

//    for (var j = firstMaxPos + 1; j < batteriesCount; j++)
//    {
//        if (banks[i][j] > secondMax)
//        {
//            secondMax = banks[i][j];
//        }
//    }

//    joltage += 10 * firstMax + secondMax;
//}

//Console.WriteLine(joltage);

//--- Part Two ---
var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

var banksCount = inputLines.Length;
var batteriesCount = inputLines[0].Length;

var banks = new int[banksCount][];

for (var i = 0; i < banksCount; i++)
{
    banks[i] = new int[batteriesCount];

    for (var j = 0; j < batteriesCount; j++)
    {
        banks[i][j] = inputLines[i][j] - '0';
    }
}

var globalJoltage = 0L;

for (var i = 0; i < banksCount; i++)
{
    var bankJoltage = 0L;

    var maxPos = -1;

    for (var n = 0; n < 12; n++)
    {
        var max = 0;

        for (var j = maxPos + 1; j < batteriesCount + n - 11; j++)
        {
            if (banks[i][j] > max)
            {
                max = banks[i][j];
                maxPos = j;
            }
        }

        bankJoltage += (long)Math.Pow(10, 11 - n) * max;
    }

    globalJoltage += bankJoltage;
}

Console.WriteLine(globalJoltage);
