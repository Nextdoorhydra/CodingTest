PriorityQueue<int, int> pq = new();
Enumerable.Range(0, int.Parse(Console.ReadLine()))
    .Select(_ => int.Parse(Console.ReadLine())).ToList()
    .ForEach(x => pq.Enqueue(x, x));

int shuffle = 0, sum;
while(pq.Count > 1)
{
    sum = pq.Dequeue() + pq.Dequeue();
    shuffle += sum;
    pq.Enqueue(sum, sum);
}

Console.WriteLine(shuffle);