var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var seq = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
using StreamWriter sw = new(Console.OpenStandardOutput(), bufferSize: input[0]);
var pq = new PriorityQueue<int, int>();
var dic = new Dictionary<int, int>();
int l = 0, r = 0, k, sub;

while (r < input[1])
{
    k = seq[r++];
    pq.Enqueue(k, k);

    sw.WriteLine(pq.Peek());
}

while (r < input[0])
{
    k = seq[r++];
    sub = seq[l++];
    pq.Enqueue(k, k);

    if (dic.ContainsKey(sub))
    {
        dic[sub]++;
    }
    else
    {
        dic.Add(sub, 1);
    }

    while (dic.ContainsKey(pq.Peek()) && dic[pq.Peek()] > 0)
    {
        dic[pq.Peek()]--;
        pq.Dequeue();
    }

    sw.WriteLine(pq.Peek());
}