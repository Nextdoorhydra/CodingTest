using static state;
var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
List<List<int>> edgeList;
int testCase = read().First(), N, E;

for(int t = 0; t < testCase; t++)
{
    var input = read();
    N = input.First(); E = input.Last();
    edgeList = Enumerable.Range(0, N + 1).Select(_ => new List<int>()).ToList();

    for (int i = 0; i < E; i++)
    {
        input = read();
        edgeList[input.First()].Add(input.Last());
        edgeList[input.Last()].Add(input.First());
    }

    Console.WriteLine(bfs() ? "YES" : "NO");
}

bool bfs()
{
    Queue<int> queue = new Queue<int>();
    List<state>  nodeState = Enumerable.Range(0, N + 1).Select(_ => NOTHING).ToList();
    
    for(int i = 1; i <= N; i++)
    {
        if (nodeState[i] != NOTHING) continue;

        nodeState[i] = RED;
        queue.Enqueue(i);

        while (queue.Count > 0)
        {
            var pos = queue.Dequeue();

            foreach (var next in edgeList[pos])
            {
                if (nodeState[next] == NOTHING)
                {
                    nodeState[next] = nodeState[pos] switch { RED => BLUE, _ => RED };
                    queue.Enqueue(next);
                }
                else if (nodeState[next] == nodeState[pos])
                {
                    return false;
                }
            }
        }
    }
    return true;
}

enum state { NOTHING, RED, BLUE }