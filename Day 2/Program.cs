//--- Day 2: Gift Shop ---
//var input = File.ReadAllText(@"..\..\..\Input.txt");

//var ranges = input.Split(',').Select(range =>
//{
//    var parts = range.Split('-');
//    return (long.Parse(parts[0]), long.Parse(parts[1]));
//}).ToList();

//long sum = 0;

//foreach (var range in ranges)
//{
//    for (var num = range.Item1; num <= range.Item2; num++)
//    {
//        var strNum = num.ToString();
//        var strLen = strNum.Length;

//        if (strLen % 2 != 0)
//        {
//            continue;
//        }

//        if (strNum[..(strLen / 2)] == strNum[(strLen / 2)..])
//        {
//            sum += num;
//        }
//    }
//}

//Console.WriteLine(sum);

//--- Part Two ---
var input = File.ReadAllText(@"..\..\..\Input.txt");

var ranges = input.Split(',').Select(range =>
{
    var parts = range.Split('-');
    return (long.Parse(parts[0]), long.Parse(parts[1]));
}).ToList();

long sum = 0;

foreach (var range in ranges)
{
    for (var num = range.Item1; num <= range.Item2; num++)
    {
        var strNum = num.ToString();
        var strLen = strNum.Length;

        if (strLen > 1)
        {
            var isMatch = true;
            var pattern = strNum[..1];

            for (var len = 1; len < strLen; len++)
            {
                if (strNum.Substring(len, 1) != pattern)
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch)
            {
                sum += num;
                continue;
            }
        }

        if (strLen > 2 && strLen % 2 == 0)
        {
            var isMatch = true;
            var pattern = strNum[..2];

            for (var len = 2; len < strLen; len += 2)
            {
                if (strNum.Substring(len, 2) != pattern)
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch)
            {
                sum += num;
                continue;
            }
        }

        if (strLen > 3 && strLen % 3 == 0)
        {
            var isMatch = true;
            var pattern = strNum[..3];

            for (var len = 3; len < strLen; len += 3)
            {
                if (strNum.Substring(len, 3) != pattern)
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch)
            {
                sum += num;
                continue;
            }
        }

        if (strLen > 4 && strLen % 4 == 0)
        {
            var isMatch = true;
            var pattern = strNum[..4];

            for (var len = 4; len < strLen; len += 4)
            {
                if (strNum.Substring(len, 4) != pattern)
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch)
            {
                sum += num;
                continue;
            }
        }

        if (strLen > 5 && strLen % 5 == 0)
        {
            var isMatch = true;
            var pattern = strNum[..5];

            for (var len = 5; len < strLen; len += 5)
            {
                if (strNum.Substring(len, 5) != pattern)
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch)
            {
                sum += num;
            }
        }
    }
}

Console.WriteLine(sum);
