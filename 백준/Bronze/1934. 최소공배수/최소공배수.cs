Console.WriteLine(string.Join("\n", Enumerable.Range(0, int.Parse(Console.ReadLine())).ToList()
    .Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList())
    .Select(x => x[1] * x[0] / gcd(x[1], x[0]))));

int gcd(int a, int b)
{
    if (a % b == 0) return b;
    return gcd(b, a % b);
}