using System.Collections;
using System.Collections.Immutable;

var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
int N = read()[0], M = read()[0], start = 0, end = 0, ANS = 0;
Queue<int> que = new();
var indegree = new int[N];
var edgeList = Enumerable.Range(0, N).Select(x => new List<(int next, int weight)>()).ToList();
var I_LOVE_MANAKA_RARA = Enumerable.Repeat(0, N).Select(x => (time: 0, route: new BitArray(100000))).ToList();
Dictionary<(int, int), int> route = new();

for (int i = 0; i <= M; i++)
{
    var input = read();
    if (i == M)
    {
        start = input[0] - 1;
        end = input[1] - 1;
        break;
    }

    route.Add((input[0] - 1, input[1] - 1), i);
    indegree[input[1] - 1]++;
    edgeList[input[0] - 1].Add((input[1] - 1, input[2]));
}

que.Enqueue(start);

while (que.Count > 0)
{
    int pos = que.Dequeue();

    if (pos == end)
        break;

    foreach (var edge in edgeList[pos])
    {

        indegree[edge.next]--;

        int preTime = I_LOVE_MANAKA_RARA[edge.next].time,
            postTime = I_LOVE_MANAKA_RARA[pos].time + edge.weight;

        if (preTime < postTime)
        {
            var newBitArray = new BitArray(I_LOVE_MANAKA_RARA[pos].route);
            newBitArray.Set(route[(pos, edge.next)], true);

            I_LOVE_MANAKA_RARA[edge.next] = (
                I_LOVE_MANAKA_RARA[pos].time + edge.weight,
                newBitArray);
        }
        else if (preTime == postTime)
        {
            I_LOVE_MANAKA_RARA[edge.next].route.Set(route[(pos, edge.next)], true);
            I_LOVE_MANAKA_RARA[edge.next] = (
            I_LOVE_MANAKA_RARA[edge.next].time,
            I_LOVE_MANAKA_RARA[edge.next].route.Or(I_LOVE_MANAKA_RARA[pos].route));
        }

        if (indegree[edge.next] == 0) que.Enqueue(edge.next);
    }
}

for(int i = 0; i < I_LOVE_MANAKA_RARA[end].route.Count; i++) if (I_LOVE_MANAKA_RARA[end].route[i]) ANS++;
Console.WriteLine($"{I_LOVE_MANAKA_RARA[end].time}\n{ANS}");