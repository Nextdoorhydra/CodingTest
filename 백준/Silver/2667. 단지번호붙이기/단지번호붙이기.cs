var size = int.Parse(Console.ReadLine());
var map = new int[size, size];

for (int row = 0; row < size; row++)
{
    var input = Console.ReadLine();
    for (int col = 0; col < size; col++) map[row, col] = input[col] - '0';
}

var dx = new int[] { 1, 0, -1, 0 }; var dy = new int[] { 0, 1, 0, -1 };

Func<(int x, int y), bool> IsPassable = c => c.x >= 0 && c.y >= 0 && c.x < size && c.y < size;

Queue<(int, int)> queue = new Queue<(int, int)>();
List<int> log = new List<int>();
queue.Enqueue((0, 0));

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        if (map[row, col] != 1) continue;
        queue.Enqueue((row, col));
        map[row, col]++;

        int count = 1;
        while (queue.Count > 0)
        {
            (int x, int y) now = queue.Dequeue();
            for (int xy = 0; xy < 4; xy++)
            {
                (int x, int y) next = (now.x + dx[xy], now.y + dy[xy]);

                if (IsPassable(next) && map[next.x, next.y] == 1)
                {
                    count++;
                    map[next.x, next.y]++;
                    queue.Enqueue(next);
                }
            }
        }
        log.Add(count);
    }
}

log.Sort();
Console.WriteLine($"{log.Count()}\n{string.Join('\n', log)}");