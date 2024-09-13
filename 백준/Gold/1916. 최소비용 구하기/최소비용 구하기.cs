using static System.Console;

var v = Enumerable.Range(0, int.Parse(ReadLine()) + 1).Select(_ => int.MaxValue).ToList();
var edgeList = Enumerable.Range(0, v.Count).Select(_ => new List<(int v, int weight)>()).ToList();

foreach(var i in Enumerable.Range(0, int.Parse(ReadLine())))
{
    var temp = ReadLine().Split().Select(int.Parse).ToList();
    edgeList[temp[0]].Add((temp[1], temp[2]));
}

var input = ReadLine().Split().Select(int.Parse).ToList();
int start = input[0], end = input[1];

PriorityQueue<int, int> pq = new();
pq.Enqueue(start, 0);
v[start] = 0;

while(pq.Count > 0 && pq.Peek() != end)
{
    var current = pq.Dequeue();

    foreach(var next in edgeList[current])
    {
        int distance = v[current] + next.weight;

        if(distance < v[next.v])
        {
            v[next.v] = distance;
            pq.Enqueue(next.v, distance);
        }
    }
}

WriteLine(v[end]);