using static System.Math;
const int R = 0, G = 1, B = 2, INF = 1_000_000;
var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
int N = read()[0], l = 1, ANSWER = int.MaxValue;
var data = Enumerable.Range(0, N).Select(_ => read()).ToList();
var dp = Enumerable.Range(0, 3).Select(_ => Enumerable.Range(0, N).Select(i => new List<int>(data[i])).ToList()).ToList();

dp[R][0][G] = dp[R][0][B] = dp[G][0][R] = dp[G][0][B] = dp[B][0][R] = dp[B][0][G] = INF;

while (l < N)
{
    foreach (var c in new[] { R, G, B })
    {
        dp[c][l][0] += Min(dp[c][l - 1][1], dp[c][l - 1][2]);
        dp[c][l][1] += Min(dp[c][l - 1][0], dp[c][l - 1][2]);
        dp[c][l][2] += Min(dp[c][l - 1][0], dp[c][l - 1][1]);
    }
    l++;
}

dp[R][N - 1][R] = dp[G][N - 1][G] = dp[B][N - 1][B] = INF;

Console.WriteLine(Min(Min(dp[R][N - 1].Min(), dp[G][N - 1].Min()), dp[B][N-1].Min()));