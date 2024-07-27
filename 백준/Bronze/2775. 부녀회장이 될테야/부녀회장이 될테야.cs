using System.Text;

StringBuilder sb = new StringBuilder();

int rep = int.Parse(Console.ReadLine());

int[,] arr = new int[rep, 2];

for(int i = 0; i < rep; i++)

{
    arr[i, 0] = int.Parse(Console.ReadLine());
    arr[i, 1] = int.Parse(Console.ReadLine());
}

for(int i = 0; i < rep; i++)
{
    sb.Append($"{recur(arr[i, 0], arr[i, 1])}\n");
}

Console.WriteLine(sb.ToString());

int recur(int f, int n)
{
    int sum = 0;
    if (f == 0) return n;
    for(int i = 1; i <= n; i++)
    {
        sum += recur(f - 1, i);
    }
    return sum;
}