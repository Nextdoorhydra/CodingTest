var read = () => Console.ReadLine().Split().Select(long.Parse).ToArray();
long T = read()[0], n = read()[0], m; var seq1 = read(); m = read()[0]; var seq2 = read();
long ANSWER = 0;
Dictionary<long, long> dic = new(), dic2 = new();

doubleFor((int i, int j) =>
{
    long sum = seq1[i..(i + j)].Sum();
    if (!dic.TryAdd(sum, 1)) dic[sum]++;
}, n);

doubleFor((int i, int j) =>
{
    long sum = seq2[i..(i + j)].Sum();
    if (dic.ContainsKey(T - sum)) ANSWER += dic[T - sum];
}, m);

Console.WriteLine(ANSWER);

void doubleFor(Action<int, int> f, long size)
{
    for (int j = 1; j <= size; j++)
    {
        for (int i = 0; i <= size - j; i++)
        {
            f(i, j);
        }
    }
}