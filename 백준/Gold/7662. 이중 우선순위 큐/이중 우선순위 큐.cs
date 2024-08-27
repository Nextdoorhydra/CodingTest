using StreamWriter sw = new(Console.OpenStandardOutput());

for (int r = int.Parse(Console.ReadLine()); r > 0; r--)
{
    long max, min, k;
    var dic = new Dictionary<long, int>();
    PriorityQueue<long, long> maxQ = new(), minQ = new();

    var deque = (PriorityQueue<long, long> Q, int sw) =>
    {
        while (Q.Count > 0 && dic[sw * Q.Peek()] == 0) Q.Dequeue();
    };

    for (int _r = int.Parse(Console.ReadLine()); _r > 0; _r--)
    {
        var input = Console.ReadLine().Split();
        k = int.Parse(input[1]);

        switch (input[0])
        {
            case "I":
                maxQ.Enqueue(-k, -k); minQ.Enqueue(k, k);

                if (dic.ContainsKey(k))
                {
                    dic[k]++;
                }
                else
                {
                    dic.Add(k, 1);
                }
                break;
            case "D":
                if (k == 1)
                {
                    deque(maxQ, -1);
                    if (maxQ.Count > 0) dic[-maxQ.Dequeue()]--;
                }
                else
                {
                    deque(minQ, 1);
                    if (minQ.Count > 0) dic[minQ.Dequeue()]--;
                }
                break;
        }
    }
    deque(maxQ, -1); deque(minQ, 1);

    sw.WriteLine((maxQ.TryDequeue(out max, out _), minQ.TryDequeue(out min, out _)) switch
    {
        (true, true) => $"{-max} {min}",
        (true, false) => $"{-max} {-max}",
        (false, true) => $"{min} {min}",
        _ => "EMPTY"
    });
}