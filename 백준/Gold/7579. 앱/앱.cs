var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
var input = read();
int N = input[0], M = input[1], ANSWER = int.MaxValue;
var memory = read(); var cost = read();
var ls = memory.Zip(cost, (m, c) => (m: m, c: c)).ToList();
var dp = new int[N + 1, cost.Sum() + 1];

for (int i = 0; i < N + 1; i++)
{
    for(int c = 0; c < cost.Sum() + 1; c++)
    {
        if (i == 0)
            dp[i, c] = 0;
        else if (ls[i - 1].c <= c)
            dp[i, c] = Math.Max(dp[i - 1, c], dp[i - 1, c - ls[i - 1].c] + ls[i - 1].m);
        else
            dp[i, c] = dp[i - 1, c];

        if (dp[i, c] >= M)
        {
            ANSWER = Math.Min(ANSWER, c);
        }
    }
}

Console.WriteLine(ANSWER);