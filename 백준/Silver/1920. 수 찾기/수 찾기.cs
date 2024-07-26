using System.Text;

int N = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
int M = int.Parse(Console.ReadLine());
int[] ans = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

HashSet<int> hashSet = new HashSet<int>(arr);
StringBuilder sb = new StringBuilder();

for (int i = 0; i < M; i++)
{
    if (hashSet.Contains(ans[i]))
    {
        sb.Append("1\n");
    }
    else
    {
        sb.Append("0\n");
    }
}
Console.WriteLine(sb.ToString());