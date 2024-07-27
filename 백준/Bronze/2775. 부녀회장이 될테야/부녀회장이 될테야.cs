using System.Text;

StringBuilder sb = new StringBuilder();
int rep = int.Parse(Console.ReadLine());
int[,] arr = new int[rep, 2];

for(int i = 0; i < rep; i++)
{
    arr[i, 0] = int.Parse(Console.ReadLine()); arr[i, 1] = int.Parse(Console.ReadLine());
}

int[,] memo = new int[15, 15];
for(int i = 0; i < 15; i++) memo[0, i] = i + 1;
int recur(int f, int n)
{
    if(memo[f, n - 1] != 0) return memo[f, n - 1];
    if (f == 0) return memo[0, n - 1];
    memo[f, n - 1] = Enumerable.Range(1, n).Select(i => recur(f - 1, i)).Sum();
    return memo[f, n - 1];
}

for (int i = 0; i < rep; i++) sb.Append($"{recur(arr[i, 0], arr[i, 1])}\n");

Console.WriteLine(sb.ToString());