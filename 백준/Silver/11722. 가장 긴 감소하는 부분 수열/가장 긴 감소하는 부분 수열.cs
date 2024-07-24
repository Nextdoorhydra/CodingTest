int[] cnt = new int[int.Parse(Console.ReadLine())]; Array.Fill(cnt, 1);
int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

for(int i = arr.Length - 1; i >= 0; i--)
{
    for(int j = arr.Length - 1; j > i; j--)
    {
        if (arr[i] > arr[j]) cnt[i] = Math.Max(cnt[i], cnt[j] + 1);
    }
}
Console.WriteLine(cnt.Max());