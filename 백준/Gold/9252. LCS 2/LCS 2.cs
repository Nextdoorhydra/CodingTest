string s1 = Console.ReadLine(), s2 = Console.ReadLine();
var dp = new int[s1.Length + 1, s2.Length + 1];

for (int i = 0; i < s1.Length; i++)
    for (int j = 0; j < s2.Length; j++)
        dp[i + 1, j + 1] = s1[i] == s2[j] ? dp[i, j] + 1 : Math.Max(dp[i + 1, j], dp[i, j + 1]);

dfs(s1.Length, s2.Length, "");

void dfs(int i, int j, string LCS)
{
    if (dp[i, j] == 0) Console.WriteLine($"{LCS.Length}\n" + LCS);
    else if (dp[i, j] == dp[i - 1, j]) dfs(i - 1, j, LCS);
    else if (dp[i, j] == dp[i, j - 1]) dfs(i, j - 1, LCS);
    else dfs(i - 1, j - 1, s2[j - 1] + LCS);
}