var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

Queue<int> q = new Queue<int>();
foreach (var i in Enumerable.Range(1, input[0])) q.Enqueue(i);

var ls = new List<int>();
for(; q.Count > 0; ls.Add(q.Dequeue())) for (int i = 1; i < input[1]; i++) q.Enqueue(q.Dequeue());

Console.WriteLine($"<{string.Join(", ", ls)}>");