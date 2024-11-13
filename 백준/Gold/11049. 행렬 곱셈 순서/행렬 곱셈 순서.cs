var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
int N = read()[0];
var m = Enumerable.Range(0, N).Select(_ => read()).ToList();
var dp = new int[N, N];

for (int i = 0; i + 1 < N; i++)
    dp[i, i + 1] = m[i][0] * m[i][1] * m[i + 1][1];

for (int i = 1; i < N; i++)
    for (int j = 0; j + i + 1 < N; j++)
    {
        int min = dp[j, j + i] + m[j][0] * m[j + i][1] * m[j + i + 1][1];

        for (int k = 1; k <= i; k++)
            min = Math.Min(min, m[j][0] * m[j + k - 1][1] * m[j + i + 1][1] + dp[j + k, j + i + 1] + dp[j, j + k - 1]);

        dp[j, j + i + 1] = min;
    }

Console.WriteLine(dp[0, N - 1]);