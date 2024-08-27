using StreamWriter sw = new(Console.OpenStandardOutput());

for (int r = int.Parse(Console.ReadLine()); r > 0; r--)
{
    var dic = new Dictionary<long, int>();

    var maxQ = new PriorityQueue<long, long>();
    var minQ = new PriorityQueue<long, long>();

    for (int _r = int.Parse(Console.ReadLine()); _r > 0; _r--)
    {
        var input = Console.ReadLine().Split();
        long k = int.Parse(input[1]);

        switch (input[0])
        {
            case "I":
                maxQ.Enqueue(-k, -k);
                minQ.Enqueue(k, k);

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
                if (maxQ.Count > 0 && k == 1)
                {
                    while (maxQ.Count > 0 && dic[-maxQ.Peek()] == 0) maxQ.Dequeue();

                    if (maxQ.Count > 0)
                    {
                        dic[-maxQ.Dequeue()]--;
                    }
                }
                else if (minQ.Count > 0 && k == -1)
                {
                    while (minQ.Count > 0 && dic[minQ.Peek()] == 0) minQ.Dequeue();

                    if (minQ.Count > 0)
                    {
                        dic[minQ.Dequeue()]--;
                    }
                }
                break;
        }
    }

    long max, min;

    while (maxQ.Count > 0 && dic[-maxQ.Peek()] == 0) maxQ.Dequeue();
    while (minQ.Count > 0 && dic[minQ.Peek()] == 0) minQ.Dequeue();

    sw.WriteLine((maxQ.TryDequeue(out max, out _), minQ.TryDequeue(out min, out _)) switch
    {
        (true, true) => $"{-max} {min}",
        (true, false) => $"{-max} {-max}",
        (false, true) => $"{min} {min}",
        _ => "EMPTY"
    });
}