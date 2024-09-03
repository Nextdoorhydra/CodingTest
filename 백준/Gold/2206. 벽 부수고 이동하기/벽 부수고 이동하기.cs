var NM = Console.ReadLine().Split().Select(int.Parse).ToList();
int N = NM[0], M = NM[1], answer = int.MaxValue;

var visited = Enumerable.Range(0, N)
    .Select(_ => Enumerable.Range(0, M).Select(_ => false).ToList())
    .ToList();
var map = Enumerable.Range(0, N)
    .Select(_ => Console.ReadLine().Select(c => -int.Parse(c.ToString())).ToList())
    .ToList();


var move = new Func<(int x, int y), (int x, int y)>[]
{
    pos => (pos.x + 1, pos.y),
    pos => (pos.x - 1, pos.y),
    pos => (pos.x, pos.y + 1),
    pos => (pos.x, pos.y - 1)
};
var IsInRange = ((int x, int y) pos) => pos.x >= 0 && pos.y >= 0 && pos.x < N && pos.y < M;
var to3tuple = ((int x, int y) v2, int z) => (v2.x, v2.y, z);
var to2tuple = ((int x, int y, int z) v3) => (v3.x, v3.y);

bfs(1);

void bfs(int boom)
{
    Queue<(int x, int y)> queue = new();
    Queue<(int x, int y)> queue2 = new();
    queue.Enqueue((0, 0));
    map[0][0] = 1;
    visited[0][0] = true;

    while (queue.Count > 0)
    {
        var now = queue.Dequeue();

        foreach (var f in move)
        {
            var next = f(now);

            if (!IsInRange(next)) continue;
            var state = map[next.x][next.y];

            if (state == 0)
            {
                map[next.x][next.y] = map[now.x][now.y] + 1;
                queue.Enqueue(next);
            }
            else if (state == -1)
            {
                visited[next.x][next.y] = true;
                map[next.x][next.y] = map[now.x][now.y] + 1;
                queue2.Enqueue(next);
            }
        }
    }

    while (queue2.Count > 0)
    {
        var now = queue2.Dequeue();

        foreach (var f in move)
        {
            var next = f(now);
            if (!IsInRange(next) || visited[next.x][next.y]) continue;

            var state = map[next.x][next.y];

            if (state == 0)
            {
                map[next.x][next.y] = map[now.x][now.y] + 1;
                queue2.Enqueue(next);
            }
            else if (state != -1)
            {
                if(map[next.x][next.y] > map[now.x][now.y] + 1)
                {
                    map[next.x][next.y] = map[now.x][now.y] + 1;
                    queue2.Enqueue(next);
                }
            }
        }
    }

    Console.WriteLine(map[^1][^1] > 0 ? map[^1][^1] : -1);
}

void display()
{
    Console.WriteLine();
    for (int i = 0; i < map.Count; i++)
    {
        for (int j = 0; j < map[i].Count; j++)
        {
            Console.Write($"{map[i][j],2}");
        }
        Console.WriteLine();
    }
}