int n = int.Parse(Console.ReadLine());

var memo = new Dictionary<int, int>()
{
    [0] = int.MaxValue,
    [1] = 0,
    [2] = 1,
    [3] = 1,
};

Func<int, int, int> div = (x, d) => x % d == 0 ? x / d : 0;
for(int i = 4; i <= n; i++)
{
    memo.Add(i, 1 + Math.Min(Math.Min(memo[div(i, 2)], memo[div(i, 3)]), memo[i - 1]));
}

Console.WriteLine(memo[n]);