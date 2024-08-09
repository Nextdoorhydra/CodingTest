int n = int.Parse(Console.ReadLine());

var g = new char[n, n];

for(int row = 0; row < n; row++)
{
    var input = Console.ReadLine();

    for (int col = 0; col < n; col++)
    {
        g[row, col] = input[col];
    }
}

var dx = new int[] { 1, 0, -1, 0 };
var dy = new int[] { 0, 1, 0, -1 };

Func<(int x, int y), bool> IsPassable = c =>{ return c switch { (int x, int y) when x >= 0 && y >= 0 && x < n && y < n => true, _ => false }; };

Queue<(int, int)> queue = new Queue<(int, int)> ();

Console.WriteLine($"{bfs((a, b) => { return a == b; })} {bfs((a, b) => { return (a, b) switch { ('R', 'G') or ('G', 'R') => true, _ when a == b => true, _ => false };})}");

int bfs(Func<char, char, bool> view)
{
    var visited = new bool[n, n];

    int cnt = 0;
    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < n; col++)
        {
            if (visited[row, col]) continue;
            queue.Enqueue((row, col));

            while (queue.Count > 0)
            {
                (int x, int y) c = queue.Dequeue();

                if (visited[c.x, c.y]) continue;

                visited[c.x, c.y] = true;

                for (int xy = 0; xy < 4; xy++)
                {
                    (int x, int y) dxy = (c.x + dx[xy], c.y + dy[xy]);
                    if (IsPassable(dxy) && view(g[dxy.x, dxy.y], g[c.x, c.y]))
                    {
                        queue.Enqueue(dxy);
                    }
                }
            }
            cnt++;
        }
    }
    return cnt;
}