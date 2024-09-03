var NM = Console.ReadLine().Split().Select(int.Parse).ToList();
int N = NM[0], M = NM[1], answer;

var visit = new int[N, M, 2];
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

answer = N > 1 || M > 1 ? bfs() : 1;
Console.WriteLine(answer switch { 0 => -1, _ => answer });

int bfs()
{
    Queue<(int x, int y, int z)> queue = new();
    queue.Enqueue((0, 0, 1));
    visit[0, 0, 1] = 1;

    while(queue.Count > 0)
    {
        var now = queue.Dequeue();
        var time = visit[now.x, now.y, now.z];

        foreach(var f in move)
        {
            var next = f((now.x, now.y));
            if (!IsInRange((next.x, next.y))) continue;
            var state = map[next.x][next.y];

            if(next.x == N - 1 && next.y == M - 1)
            {
                return time + 1;
            }
            else if(state == 0 && visit[next.x, next.y, now.z] == 0)
            {
                visit[next.x, next.y, now.z] = time + 1;
                queue.Enqueue((next.x, next.y, now.z));
            }
            else if(state == -1 && now.z > 0 && visit[next.x, next.y, 1] == 0)
            {
                visit[next.x, next.y, 0] = time + 1;
                queue.Enqueue((next.x, next.y, 0));
            }
        }
    }
    return 0;
}