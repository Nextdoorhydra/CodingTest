var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
var input = read();
int N = input[0], M = input[1];
var indegree = Enumerable.Repeat(0, N).ToList();
var edgeList = Enumerable.Range(0, N).Select(_ => new HashSet<int>()).ToList();

for(int i = 0; i < M; i++)
{
    input = read().Skip(1).Select(x => x - 1).ToList();
    input.Skip(1).Aggregate(input[0], (pre, x) => 
    {
        if (!edgeList[pre].Contains(x))
        {
            edgeList[pre].Add(x);
            indegree[x]++;
        }
        return x;
    });
}

List<int> route = new();
Queue<int> q = new();
for (int i = 0; i < N; i++) if (indegree[i] == 0) q.Enqueue(i);

while(q.Count > 0)
{
    int pos = q.Dequeue();
    route.Add(pos);

    foreach(var next in edgeList[pos])
    {
        indegree[next]--;
        if (indegree[next] == 0)
        {
            q.Enqueue(next);
        }
    }
}

Console.WriteLine(route.Count != N ? "0" : string.Join("\n", route.Select(x => x + 1)));