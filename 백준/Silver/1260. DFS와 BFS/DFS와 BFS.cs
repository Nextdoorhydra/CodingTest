var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

var edge = Enumerable.Range(0, input[0]).Select(x => new List<int>()).ToList();

for (int i = 0; i < input[1]; i++)
{
    var get = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    edge[get[0] - 1].Add(get[1] - 1);
    edge[get[1] - 1].Add(get[0] - 1);
}

for (int i = 0; i < edge.Count; i++) edge[i].Sort();

Console.WriteLine(string.Join(" ", dfs(edge)));
Console.WriteLine(string.Join(" ", bfs(edge)));

List<int> bfs(List<List<int>> e)
{
    Queue<int> que = new Queue<int>();
    var log = new List<int>();
    var visited = new bool[input[0]];

    que.Enqueue(input[2] - 1);
    visited[input[2] - 1] = true;

    while (que.Count > 0)
    {
        var now = que.Dequeue();
        if(!log.Contains(now + 1)) log.Add(now + 1);

        foreach (var next in edge[now])
        {
            if (!visited[next])
            {
                visited[now] = true;
                que.Enqueue(next);
            }
        }
    }

    return log;
}

List<int> dfs(List<List<int>> e)
{
    Stack<int> st = new Stack<int>();
    var log = new List<int>();
    var visited = new bool[input[0]];

    st.Push(input[2] - 1);
    visited[input[2] - 1] = true;

    while (st.Count > 0)
    {
        var now = st.Pop();
        visited[now] = true;
        if (!log.Contains(now + 1)) log.Add(now + 1);

        foreach (var next in edge[now].AsEnumerable().Reverse())
        {
            if (!visited[next])
            {
                st.Push(next);
            }
        }
    }

    return log;
}
