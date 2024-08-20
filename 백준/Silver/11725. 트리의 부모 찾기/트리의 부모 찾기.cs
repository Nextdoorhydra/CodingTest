int size = int.Parse(Console.ReadLine());
var ans = new int[size];
var visited = new bool[size];
var edgeList = Enumerable.Range(1, size).Select(x => new List<int>()).ToList();

while (--size > 0)
{
    var v = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    edgeList[--v[0]].Add(--v[1]);
    edgeList[v[1]].Add(v[0]);
}

Queue<int> queue = new Queue<int>(new int[1]);
visited[0] = true;

while (queue.Count > 0)
{
    var pos = queue.Dequeue();

    foreach(var v in edgeList[pos])
    {
        if (!visited[v])
        {
            visited[v] = true;
            queue.Enqueue(v);
            ans[v] = pos + 1;
        }
    }
}

Console.WriteLine(string.Join("\n", ans[1..]));