//--- Day 1: Secret Entrance ---
//var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

//var start = 50;
//var count = 0;

//foreach (var inputLine in inputLines)
//{
//    var direction = inputLine[0];
//    var number = int.Parse(inputLine[1..]);

//    switch (direction)
//    {
//        case 'L':
//            start -= number;
//            break;
//        case 'R':
//            start += number;
//            break;
//    }

//    while (start is < 0 or > 99)
//    {
//        if (start < 0)
//        {
//            start += 100;
//        }
//        else
//        {
//            start -= 100;
//        }
//    }

//    if (start == 0)
//    {
//        count++;
//    }
//}

//Console.WriteLine(count);

//--- Part Two ---
var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

var start = 50;
var count = 0;

foreach (var inputLine in inputLines)
{
    var direction = inputLine[0] == 'L' ? -1 : 1;
    var number = int.Parse(inputLine[1..]);

    var toZero = direction == -1 ? start : 100 - start;

    if (toZero > 0 && number >= toZero)
    {
        count++;
    }

    count += (number - toZero) / 100;

    start += direction * number;
    start %= 100;

    if (start < 0)
    {
        start += 100;
    }
}

Console.WriteLine(count);
