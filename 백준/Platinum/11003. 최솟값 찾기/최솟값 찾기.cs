StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var seq = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var pq = new PriorityQueue<int, int>();
var dic = new Dictionary<int, int>();

int l = 0, r = 0, k, remove;

//초기 처리
while (r < input[1])
{
    k = seq[r++];
    pq.Enqueue(k, k);

    sw.Write(pq.Peek() + " ");
}

while (r < input[0])
{
    k = seq[r++];
    remove = seq[l++];
    pq.Enqueue(k, k);

    if (dic.ContainsKey(remove))
    {
        dic[remove]++;
    }
    else
    {
        dic.Add(remove, 1);
    }

    while (dic.ContainsKey(pq.Peek()) && dic[pq.Peek()] > 0)
    {
        dic[pq.Peek()]--;
        pq.Dequeue();
    }

    sw.Write(pq.Peek() + " ");
}
sr.Close();
sw.Close();