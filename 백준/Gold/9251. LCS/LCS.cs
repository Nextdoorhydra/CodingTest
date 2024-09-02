var str1 = Console.ReadLine();
var str2 = Console.ReadLine();

var dp = new int[str1.Length + 1, str2.Length + 1];

for(int i = 1; i <= str1.Length; i++)
{
    for(int j = 1; j <= str2.Length; j++)
    {
        if (str1[i - 1] == str2[j - 1])
        {
            dp[i, j] = dp[i - 1, j - 1] + 1;
        }
        else
        {
            dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
        }
    }
}

Console.WriteLine(dp[str1.Length, str2.Length]);