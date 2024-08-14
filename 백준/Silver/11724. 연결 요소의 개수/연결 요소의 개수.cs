var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

var visited = new bool[input[0]];
var V = Enumerable.Range(0, input[0]).ToArray();
var E = Enumerable.Range(0, input[0]).Select(i => new List<int>()).ToList();

for (int i = 0; i < input[1]; i++)
{
    var _input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    E[--_input[0]].Add(--_input[1]);
    E[_input[1]].Add(_input[0]);
}

int ANS = 0;
Queue<int> queue = new Queue<int>();

foreach (var v in V)
{
    if (visited[v]) continue;

    ANS++;
    queue.Enqueue(v);
    visited[v] = true;

    while (queue.Count > 0)
    {
        int now = queue.Dequeue();

        foreach (var e in E[now])
        {
            if (!visited[e])
            {
                visited[e] = true;
                queue.Enqueue(e);
            }
        }
    }
}

Console.WriteLine(ANS);