int n = int.Parse(Console.ReadLine());
var ans = new int[n];
var visited = new bool[n];
var ls = Enumerable.Range(1, n).Select(x => new List<int>()).ToList();
while (--n > 0)
{
    var v = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    ls[--v[0]].Add(--v[1]);
    ls[v[1]].Add(v[0]);
}

Queue<int> q = new Queue<int>(new int[1]);
visited[0] = true;
while (q.Count > 0)
{
    var pos = q.Dequeue();

    foreach(var v in ls[pos])
    {
        if (!visited[v])
        {
            visited[v] = true;
            q.Enqueue(v);
            ans[v] = pos + 1;
        }
    }
}
Console.WriteLine(string.Join("\n", ans[1..]));