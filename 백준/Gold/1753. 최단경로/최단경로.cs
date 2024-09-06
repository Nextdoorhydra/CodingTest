using static System.Console;
using StreamWriter sw = new(OpenStandardOutput());

const int INF = int.MaxValue;
PriorityQueue<(int pos, int weight), int> pq = new();
var input = ReadLine().Split().Select(int.Parse).ToList();
var start = int.Parse(ReadLine());
var MST = Enumerable.Range(1, input[0] + 1).Select(_ => INF).ToArray();
var edgeList = Enumerable.Range(1, input[0] + 1).Select(_ => new List<(int To, int weight)>()).ToList();

for (int i = 0; i < input[1]; i++)
{
    var _input = ReadLine().Split().Select(int.Parse).ToList();
    edgeList[_input[0]].Add((_input[1], _input[2]));
}

pq.Enqueue((start, 0), 0);
MST[start] = 0;

while (pq.Count > 0)
{
    var current = pq.Dequeue();

    foreach (var edge in edgeList[current.pos])
    {
        if (MST[current.pos] + edge.weight < MST[edge.To])
        {
            MST[edge.To] = MST[current.pos] + edge.weight;
            pq.Enqueue(edge, MST[edge.To]);
        }
    }
}

foreach(var i in MST.Skip(1)) sw.WriteLine(i switch { INF => "INF", _ => i });