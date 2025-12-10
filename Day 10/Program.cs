//--- Day 10: Factory ---
//var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

//var machines = new List<Machine>();

//foreach (var line in inputLines)
//{
//    var parts = line.Split(' ');

//    var state = parts[0][1..^1].Select(character => character == '#').ToArray();

//    var buttons = new List<HashSet<int>>();

//    var index = 1;
//    while (index < parts.Length && parts[index].StartsWith('('))
//    {
//        buttons.Add(parts[index][1..^1].Split(',').Select(int.Parse).ToHashSet());
//        index++;
//    }

//    var joltages = index < parts.Length && parts[index].StartsWith('{')
//        ? parts[index][1..^1].Split(',').Select(int.Parse).ToArray()
//        : [];

//    machines.Add(new Machine(state, buttons, joltages));
//}

//var total = 0;

//foreach (var machine in machines)
//{
//    for (var count = 0; count <= machine.Buttons.Count; count++)
//    {
//        if (Solve(machine, 0, count, 0, new bool[machine.State.Length]))
//        {
//            total += count;
//            break;
//        }
//    }
//}

//Console.WriteLine(total);
//return;

//bool Solve(Machine machine, int start, int target, int depth, bool[] state)
//{
//    if (depth == target)
//    {
//        return state.SequenceEqual(machine.State);
//    }

//    for (var i = start; i <= machine.Buttons.Count - (target - depth); i++)
//    {
//        ToggleLights(machine.Buttons[i], state);

//        if (Solve(machine, i + 1, target, depth + 1, state))
//        {
//            return true;
//        }

//        ToggleLights(machine.Buttons[i], state);
//    }

//    return false;
//}

//void ToggleLights(IEnumerable<int> lights, IList<bool> state)
//{
//    foreach (var index in lights.Where(index => index < state.Count))
//    {
//        state[index] = !state[index];
//    }
//}

//internal record Machine(bool[] State, List<HashSet<int>> Buttons, int[] Joltages);

//--- Part Two ---
using Microsoft.Z3;

var inputLines = File.ReadAllLines(@"..\..\..\Input.txt");

var machines = new List<Machine>();

foreach (var line in inputLines)
{
    var parts = line.Split(' ');

    var state = parts[0][1..^1].Select(character => character == '#').ToArray();

    var buttons = new List<HashSet<int>>();

    var index = 1;
    while (index < parts.Length && parts[index].StartsWith('('))
    {
        buttons.Add(parts[index][1..^1].Split(',').Select(int.Parse).ToHashSet());
        index++;
    }

    var joltages = index < parts.Length && parts[index].StartsWith('{')
        ? parts[index][1..^1].Split(',').Select(int.Parse).ToArray()
        : [];

    machines.Add(new Machine(state, buttons, joltages));
}

var total = 0;

foreach (var machine in machines)
{
    using var context = new Context();
    using var optimize = context.MkOptimize();

    var presses = Enumerable.Range(0, machine.Buttons.Count)
        .Select(i => context.MkIntConst($"p{i}"))
        .ToArray();

    foreach (var press in presses)
    {
        optimize.Add(context.MkGe(press, context.MkInt(0)));
    }

    for (var i = 0; i < machine.Joltages.Length; i++)
    {
        var lights = presses.Where((_, j) => machine.Buttons[j].Contains(i)).ToArray();

        var sum = lights.Length == 1 ? lights[0] : context.MkAdd(lights);

        optimize.Add(context.MkEq(sum, context.MkInt(machine.Joltages[i])));
    }

    optimize.MkMinimize(presses.Length == 1 ? presses[0] : context.MkAdd(presses));
    optimize.Check();

    var model = optimize.Model;
    total += presses.Sum(press => ((IntNum)model.Evaluate(press, true)).Int);
}

Console.WriteLine(total);

internal record Machine(bool[] State, List<HashSet<int>> Buttons, int[] Joltages);
