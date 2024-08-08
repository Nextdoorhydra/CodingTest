using static System.Console;

int comCount = int.Parse(ReadLine());
int n = int.Parse(ReadLine());
var visited = new bool[comCount]; visited[0] = true;
var edge = Enumerable.Range(0, comCount).Select(_ => new List<int>()).ToList();

for (int i = 0; i < n; i++)
{
    var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
    edge[--input[0]].Add(--input[1]);
    edge[input[1]].Add(input[0]);
}

Queue<int> queue = new Queue<int>();
queue.Enqueue(0);

while (queue.Count > 0)
{
    int idx = queue.Dequeue();

    var node = edge[idx];
    visited[idx] = true;

    foreach (var p in node) if (!visited[p]) queue.Enqueue(p);
}

WriteLine(visited.Count(x => x == true) - 1);