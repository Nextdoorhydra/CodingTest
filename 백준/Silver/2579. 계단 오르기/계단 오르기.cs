int[] memo = new int[300], g = new int[300];
int size = int.Parse(Console.ReadLine());
for (int i = 0; i < size; i++) g[i] = int.Parse(Console.ReadLine());

memo[0] = g[0];
memo[1] = g[0] + g[1];
memo[2] = Math.Max(g[0] + g[2], g[1] + g[2]);

for (int i = 3; i < size; i++)
{
    memo[i] = Math.Max(memo[i - 2] + g[i], memo[i - 3] + g[i] + g[i - 1]);
}

Console.WriteLine(memo[size - 1]);