using System.Text;

int N = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
int M = int.Parse(Console.ReadLine());
int[] ans = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

Array.Sort(arr);
StringBuilder sb = new StringBuilder();

for (int i = 0; i < M; i++)
{
    if (binaryMatch(arr, ans[i]))
    {
        sb.Append("1\n");
    }
    else
    {
        sb.Append("0\n");
    }
}
Console.WriteLine(sb.ToString());

bool binaryMatch(int[] arr, int n)
{
    int left = 0, right = N - 1;
    while (true)
    {
        int mid = (left + right) / 2;
        if (arr[mid] == n)
        {
            return true;
        }
        else if (arr[mid] < n)
        {
            left = mid + 1;
        }
        else if(arr[mid] > n)
        {
            right = mid - 1;
        }
        if (left > right) return false;
    }
}