int n = int.Parse(Console.ReadLine());
var dp = new (int R, int G, int B)[n];

for(int i = 0; i < n; i++)
{
    var col = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    dp[i] = (col[0], col[1], col[2]);
}

var select = ((int R, int G, int B) x, char sw) => sw switch { 'R' => (x.G, x.B), 'G' => (x.R, x.B), _ => (x.R, x.G) };
var min = ((int k1, int k2) x) => Math.Min(x.k1, x.k2);
var min3 = ((int k1, int k2, int k3) x) => Math.Min(min((x.k1, x.k2)), x.k3);

for (int i = 1; i < n; i++)
{
    dp[i].R += min(select(dp[i - 1], 'R'));
    dp[i].G += min(select(dp[i - 1], 'G'));
    dp[i].B += min(select(dp[i - 1], 'B'));
}

Console.WriteLine(min3(dp[n - 1]));
