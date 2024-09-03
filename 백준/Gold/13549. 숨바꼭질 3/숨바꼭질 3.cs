const int MAX = 100001;
var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0], k = input[1];

var queue = new Queue<(int pos, int time)>();
var visited = new bool[MAX];
var IsPassable = (int x) => x >= 0 && x < MAX;
var move = new List<Func<int, (int pos, int timelapse)>>() { x => (x * 2, 0), x => (x - 1, 1), x => (x + 1, 1) };

queue.Enqueue((n, 0));

while (queue.Count > 0)
{
    var now = queue.Dequeue();
    visited[now.pos] = true;

    if (now.pos == k)
    {
        Console.WriteLine(now.time);
        return;
    }

    foreach (var f in move)
    {
        var next = f(now.pos);
        if (IsPassable(next.pos) && !visited[next.pos])
        {
            queue.Enqueue((next.pos, next.timelapse + now.time));
        }
    }
}