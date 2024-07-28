using System.Collections.Immutable;
using System.Text;

StringBuilder sb = new StringBuilder();

while (true)
{
    int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
    if (arr[0] == 0 && arr[1] == 0 && arr[2] == 0) break;
    Array.Sort(arr);
    sb.Append(arr[0] * arr[0] + arr[1] * arr[1] == arr[2] * arr[2] ? "right\n" : "wrong\n");
}

Console.WriteLine(sb);