using static System.Console;

for (int rep = int.Parse(ReadLine()); rep > 0; rep--)
{
    var len = Array.ConvertAll(ReadLine().Split(), int.Parse);

    var g = new int[len[0], len[1]];

    for (int i = 0; i < len[2]; i++)
    {
        var get = Array.ConvertAll(ReadLine().Split(), int.Parse);
        g[get[0], get[1]] = 1;
    }

    var dr = new int[] { 1, 0, -1, 0 };
    var dc = new int[] { 0, 1, 0, -1 };

    Func<(int r, int c), bool> Check = x => x.r >= 0 && x.c >= 0 && x.r < len[0] && x.c < len[1];
    Queue<(int, int)> Q = new Queue<(int, int)>();

    int cnt = 0;
    for(int r =  0; r < len[0]; r++)
    {
        for (int c = 0; c < len[1]; c++)
        {
            if (g[r, c] != 1) continue;
            Q.Enqueue((r, c));
            g[r, c]++;

            while(Q.Count > 0)
            {
                (int r, int c) pos = Q.Dequeue();

                for(int i = 0; i < 4; i++)
                {
                    (int r, int c) dep = (pos.r + dr[i], pos.c + dc[i]);

                    if(Check(dep) && g[dep.r, dep.c] == 1)
                    {
                        g[dep.r, dep.c]++;
                        Q.Enqueue(dep);
                    }
                }
            }
            cnt++;
        }
    }
    WriteLine(cnt);
}