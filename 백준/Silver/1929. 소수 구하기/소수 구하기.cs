var input = Console.ReadLine().Split().Select(int.Parse).ToList();
int min = input[0], max = input[1] < 2 ? 2 : input[1];

var prime = new[] { 2 }.Concat(Enumerable.Range(3, max - 2)
    .Where(x => Enumerable.Range(2, (int)Math.Sqrt(x)).All(_ => x % _ != 0)));

Console.WriteLine(string.Join("\n", prime.SkipWhile(x => x < min)));