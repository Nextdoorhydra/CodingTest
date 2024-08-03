var input = new int[] { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) };

var str = input.Aggregate((acc, x) => acc * x).ToString();

var ans = Enumerable.Range(0, 10)
    .Select(x => str.Count(ch => ch == (char)('0' + x)))
    .ToArray();

Console.WriteLine(string.Join("\n", ans));