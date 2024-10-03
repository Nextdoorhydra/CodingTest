var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();

var input = read();
int N = input[0], M = input[1];
var edgeList = Enumerable.Range(0, N + 1).Select(_ => new List<int>()).ToList();

for (int i = 0; i < M; i++)
{
    input = read();
    edgeList[input[1]].Add(input[0]);
}

List<(int, int)> answer = new();

for(int i = 1; i <= N; i++)
{
    var ls = bfs(i);
    if(answer.Count == 0 || answer.First().Item1 < ls.Item1)
    {
        answer.Clear();
        answer.Add(ls);
    }
    else if(answer.First().Item1 == ls.Item1)
    {
        answer.Add(ls);
    }
}

Console.WriteLine(string.Join(" ", answer.Select(x => x.Item2)));

(int, int) bfs(int start)
{
    int count = 0;
    var visited = new bool[N + 1];
    Queue<int> queue = new Queue<int>();

    visited[start] = true;
    queue.Enqueue(start);

    while (queue.Count > 0)
    {
        var pos = queue.Dequeue();
        count++;

        foreach (var next in edgeList[pos])
        {
            if (!visited[next])
            {
                visited[next] = true;
                queue.Enqueue(next);
            }
        }
    }

    return (count, start);
}

Console.WriteLine();