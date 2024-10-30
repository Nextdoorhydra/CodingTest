var read = () => Console.ReadLine().Split().ToList();
int N = read().Select(int.Parse).First();
var data = Enumerable.Range(0, N).Select(_ => read()).ToList();
Console.WriteLine(string.Join("\n", data.OrderBy(x => int.Parse(x.First())).Select(x => string.Join(' ', x))));