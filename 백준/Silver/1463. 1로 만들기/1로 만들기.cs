int n = int.Parse(Console.ReadLine()), i = 1;

var m = new Dictionary<int, int>() { [0] = int.MaxValue, [1] = 0 };

Func<int, int, int> div = (x, d) => x % d == 0 ? x / d : 0;
while(i++ <= n)
{
    m.Add(i, 1 + Math.Min(Math.Min(m[div(i, 2)], m[div(i, 3)]), m[i - 1]));
}

Console.WriteLine(m[n]);