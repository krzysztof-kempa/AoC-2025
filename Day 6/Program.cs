//--- Day 6: Trash Compactor ---
//using System.Text.RegularExpressions;

//var input = File.ReadAllLines(@"..\..\..\Input.txt");
//var homework = input.Select(line => Regex.Replace(line, @"\s+", " ").Trim()).ToArray();

//var problemCount = homework[0].Split(' ').Length;
//var numberCount = homework.Length - 1;

//var problems = new long[problemCount][];
//var operators = new char[problemCount];

//for (var i = 0; i < problemCount; i++)
//{
//    problems[i] = new long[numberCount];
//}

//for (var i = 0; i < numberCount; i++)
//{
//    var problemLine = homework[i].Split(' ').ToArray();

//    for (var j = 0; j < problemCount; j++)
//    {
//        problems[j][i] = long.Parse(problemLine[j]);
//    }
//}

//var operatorLine = homework[numberCount].Split(' ').ToArray();

//for (var i = 0; i < problemCount; i++)
//{
//    operators[i] = char.Parse(operatorLine[i]);
//}

//var grandTotal = 0L;

//for (var i = 0; i < problemCount; i++)
//{
//    switch (operators[i])
//    {
//        case '+':
//            var sum = problems[i][0];

//            for (var j = 1; j < numberCount; j++)
//            {
//                sum += problems[i][j];
//            }

//            grandTotal += sum;

//            break;

//        case '*':
//            var product = problems[i][0];

//            for (var j = 1; j < numberCount; j++)
//            {
//                product *= problems[i][j];
//            }

//            grandTotal += product;

//            break;
//    }
//}

//Console.WriteLine(grandTotal);

//--- Part Two ---
var homework = File.ReadAllLines(@"..\..\..\Input.txt");

var numberLength = homework.Length - 1;
var lineLength = homework[0].Length;

var numbers = new List<string>();
var op = ' ';

var grandTotal = 0L;

for (var i = 0; i < lineLength; i++)
{
    var space = true;
    var number = string.Empty;

    for (var j = 0; j < numberLength; j++)
    {
        if (homework[j][i] != ' ')
        {
            number += homework[j][i];
            space = false;
        }
    }

    if (homework[numberLength][i] != ' ')
    {
        op = homework[numberLength][i];
    }

    if (!space)
    {
        numbers.Add(number);
    }
    
    if (space || i == lineLength - 1)
    {
        switch (op)
        {
            case '+':
                var sum = long.Parse(numbers[0]);

                for (var j = 1; j < numbers.Count; j++)
                {
                    sum += long.Parse(numbers[j]);
                }

                grandTotal += sum;

                break;

            case '*':
                var product = long.Parse(numbers[0]);

                for (var j = 1; j < numbers.Count; j++)
                {
                    product *= long.Parse(numbers[j]);
                }

                grandTotal += product;

                break;
        }

        numbers.Clear();
    }
}

Console.WriteLine(grandTotal);
