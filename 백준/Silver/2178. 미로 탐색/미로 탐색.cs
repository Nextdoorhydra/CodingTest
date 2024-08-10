var l = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var map = new int[l[0], l[1]];

for (int row = 0; row < l[0]; row++)
{
    var input = Console.ReadLine();
    for (int col = 0; col < l[1]; col++) map[row, col] = input[col] - '0';
}

var dx = new int[] { 1, 0, -1, 0 };
var dy = new int[] { 0, 1, 0, -1 };

Func<(int x, int y), bool> IsPassable = c => c.x >= 0 && c.y >= 0 && c.x < l[1] && c.y < l[0];
Func<(int x, int y), bool> IsEnd = c => c.x == l[1] - 1 && c.y == l[0] - 1;

Console.WriteLine(bfs());

int bfs()
{
    Queue<(int, int)> queue = new Queue<(int, int)>();
    map[0, 0] = 2;
    queue.Enqueue((0, 0));

    while (queue.Count > 0)
    {
        (int x, int y) pos = queue.Dequeue();
        for (int xy = 0; xy < 4; xy++)
        {
            (int x, int y) dpos = (pos.x + dx[xy], pos.y + dy[xy]);
            if (IsPassable(dpos) && map[dpos.y, dpos.x] == 1)
            {
                map[dpos.y, dpos.x] += map[pos.y, pos.x];

                if (IsEnd(dpos))
                {
                    goto OUT;
                }
                else
                {
                    queue.Enqueue(dpos);
                }
            }
        }
    }
    OUT: return --map[l[0] - 1, l[1] - 1];
}