int n = int.Parse(Console.ReadLine());

var memo = new int[5100];

memo[3] = 1;
memo[5] = 1;

for(int i = 6; i <= n; i++)
{
    if (memo[i - 3] != 0)
    {
        memo[i] = 1 + memo[i - 3];
    }

    if (memo[i - 5] != 0)
    {
        memo[i] = 1 + memo[i - 5];
    }
}

Console.WriteLine((memo[n] != 0 ? memo[n] : -1));