using static System.Console;

for (int rep = int.Parse(ReadLine()); rep > 0; rep--)
{
    var size = Array.ConvertAll(ReadLine().Split(), int.Parse);

    var g = new int[size[0], size[1]];

    for (int i = 0; i < size[2]; i++)
    {
        var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
        g[input[0], input[1]] = 1;
    }

    var dr = new int[] { 1, 0, -1, 0 };
    var dc = new int[] { 0, 1, 0, -1 };

    Func<(int r, int c), bool> IsPassable = x => x.r >= 0 && x.c >= 0 && x.r < size[0] && x.c < size[1];
    Queue<(int, int)> queue = new Queue<(int, int)>();

    int answer = 0;
    for(int row =  0; row < size[0]; row++)
    {
        for (int col = 0; col < size[1]; col++)
        {
            if (g[row, col] != 1) continue;
            queue.Enqueue((row, col));
            g[row, col]++;

            while(queue.Count > 0)
            {
                (int r, int c) now = queue.Dequeue();

                for(int i = 0; i < 4; i++)
                {
                    (int r, int c) next = (now.r + dr[i],  now.c + dc[i]);

                    if(IsPassable(next) && g[next.r, next.c] == 1)
                    {
                        g[next.r, next.c]++;
                        queue.Enqueue(next);
                    }
                }
            }
            answer++;
        }
    }
    Console.WriteLine(answer);
}