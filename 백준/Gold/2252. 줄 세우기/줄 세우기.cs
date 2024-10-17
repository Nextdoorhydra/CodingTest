var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
var input = read();
int N = input[0], M = input[1];
Dictionary<int, List<int>> edgeList = new();

List<int> adjacency = Enumerable.Repeat(0, N + 1).ToList(), ANSWER = new(); 
adjacency[0] = -1;
for (int i = 0; i < M; i++)
{
    input = read();
    int key = input[0], n = input[1];

    if (!edgeList.ContainsKey(key)) edgeList.Add(key, new List<int>());
    edgeList[key].Add(n);

    adjacency[n]++;
}

Queue<int> queue = new();
for(int i = 1; i <= N; i++) if (adjacency[i] == 0) queue.Enqueue(i);

for(int i = 0; i < N; i++)
{
    int now = queue.Dequeue();
    ANSWER.Add(now);

    if (!edgeList.ContainsKey(now)) continue;

    foreach(var next in edgeList[now])
    {
        adjacency[next]--;
        if (adjacency[next] == 0) queue.Enqueue(next);
    }
}

Console.WriteLine(string.Join(" ", ANSWER));