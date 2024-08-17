Console.ReadLine();
var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
var g = new List<int>(input.Distinct()); g.Sort();
Console.WriteLine(string.Join(" ", input.Select(x => g.BinarySearch(x))));