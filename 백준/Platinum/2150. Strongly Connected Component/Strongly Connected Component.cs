using static System.Net.Mime.MediaTypeNames;

var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();

var input = read();
int V = input[0], E = input[1];

var visited = new bool[V];
var answer = new List<List<int>>();
var G = Enumerable.Range(0, V).Select(i => new List<int>()).ToList();
var RG = Enumerable.Range(0, V).Select(i => new List<int>()).ToList();

for (int i = 0; i < E; i++)
{
    input = read().Select(i => i - 1).ToList();
    G[input[0]].Add(input[1]);
    RG[input[1]].Add(input[0]);
}

Stack<int> stack = new();
Queue<int> queue = new();
Stack<int> visitOrder = new();

//forward
for (int i = 0; i < V; i++)
{
    if (visited[i]) continue;
    stack.Push(i);

    while (stack.Count > 0)
    {
        var flag = true;
        var now = stack.Peek();

        if (!visited[now])
        {
            visited[now] = true;

            foreach (var next in G[now])
            {
                if (visited[next]) continue;
                stack.Push(next);
                flag = false;
            }
        }

        if (flag)
        {
            var v = stack.Pop();
            queue.Enqueue(v);
        }
    }

    while(queue.Count > 0)
    {
        var v = queue.Dequeue();
        if (!visitOrder.Contains(v))
        {
            visitOrder.Push(v);
        }
    }
}

visited = new bool[V];
stack.Clear();

//reverse
while (visitOrder.Count > 0)
{
    var top = visitOrder.Pop();
    if (visited[top]) continue;
    stack.Push(top);

    var _answer = new List<int>();

    while (stack.Count > 0)
    {
        var now = stack.Pop();
        visited[now] = true;

        _answer.Add(now);

        foreach (var next in RG[now])
        {
            if (visited[next]) continue;
            stack.Push(next);
        }
    }

    answer.Add(_answer);
}

answer.ForEach(x => x.Sort());
answer.Sort((x, y) => x[0].CompareTo(y[0]));

Console.WriteLine(answer.Count);
foreach (var x in answer)
{
    Console.WriteLine(string.Join(' ', x.Distinct().Select(val => val + 1)) + " -1");
}