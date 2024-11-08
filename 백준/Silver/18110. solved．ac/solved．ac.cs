var read = () => Console.ReadLine().Split().Select(double.Parse).ToList();
var N = (int)read()[0];
var number = Enumerable.Range(0, (int)N).Select(_ => read()[0]).OrderBy(x => x).ToList();
var mean = (int)Math.Round(N * 3.0 / 20.0, MidpointRounding.AwayFromZero);
Console.WriteLine(N == 0 ? 0 : (int)Math.Round(number.Skip(mean).Take(N - 2 * mean).Sum() / (N - 2 * mean), MidpointRounding.AwayFromZero));