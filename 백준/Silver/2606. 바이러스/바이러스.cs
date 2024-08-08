using static System.Console;

int c = int.Parse(ReadLine());
int n = int.Parse(ReadLine());

var visited = new bool[c];
var edge = Enumerable.Range(0, c).Select(_ => new List<int>()).ToList();

for (int i = 0; i < n; i++)
{
    var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
    edge[--input[0]].Add(--input[1]);
    edge[input[1]].Add(input[0]);
}

Queue<int> que = new Queue<int>();
que.Enqueue(0);

while (que.Count > 0)
{
    int idx = que.Dequeue();

    var node = edge[idx];
    visited[idx] = true;

    foreach (var p in node) if (!visited[p]) que.Enqueue(p);
}

WriteLine(visited.Count(x => x == true) - 1);