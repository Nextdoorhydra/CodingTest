using static System.Console;

ReadLine();
var g = Array.ConvertAll(ReadLine().Split(), int.Parse).ToHashSet();

ReadLine();
WriteLine(string.Join("\n", Array.ConvertAll(ReadLine().Split(), int.Parse).Select(x => g.Contains(x) ? 1 : 0)));