int ans = 0;
var n = int.Parse(Console.ReadLine());

for(; ans < n; ans++) if (ans + ans.ToString().Sum(x => x - '0') == n) break;

Console.WriteLine(ans < n ? ans : 0);