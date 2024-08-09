int n = int.Parse(Console.ReadLine());

var g = new char[n, n];

for(int row = 0; row < n; row++)
{
    var input = Console.ReadLine();

    for (int col = 0; col < n; col++)
    {
         foreach(var c in input!)
        {
            g[row, col] = input[col];
        }    
    }
}

var dx = new int[] { 1, 0, -1, 0 };
var dy = new int[] { 0, 1, 0, -1 };

Func<(int x, int y), bool> IsPassable = c =>
{
    return c switch
    {
        (int x, int y) when x >= 0 && y >= 0 && x < n && y < n => true,
        _ => false
    };
};

Queue<(int, int)> queue = new Queue<(int, int)> ();

Console.WriteLine($"{bfs(g, (a, b) => { return a == b; })} {bfs(g, (a, b) => { return (a, b) switch { ('R', 'G') or ('G', 'R') => true, _ when a == b => true, _ => false };})}");

int bfs(char[,] g, Func<char, char, bool> view)
{
    int rows = g.GetLength(0);
    int cols = g.GetLength(1);

    char[,] arr = new char[rows, cols];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            arr[i, j] = g[i, j];
        }
    }

    int cnt = 0;
    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < n; col++)
        {
            if (arr[row, col] == 'X') continue;
            queue.Enqueue((row, col));

            while (queue.Count > 0)
            {
                (int x, int y) c = queue.Dequeue();

                var color = arr[c.x, c.y];
                if (color == 'X') continue;

                arr[c.x, c.y] = 'X';

                for (int xy = 0; xy < 4; xy++)
                {
                    (int x, int y) dxy = (c.x + dx[xy], c.y + dy[xy]);
                    if (IsPassable(dxy) && view(arr[dxy.x, dxy.y], color))
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