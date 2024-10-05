HashSet<(int, int, int)> hs = new();
var limit = Console.ReadLine().Split().Select(int.Parse).ToList();
bfs(0, 0, limit[2]);
Console.WriteLine(string.Join(" ", hs.ToList().Where(x => x.Item1 == 0).Select(x => x.Item3).OrderBy(x => x)));

void bfs(int A, int B, int C)
{
    Queue<(int A, int B, int C)> queue = new();
    var rest = (int K, int sub) => K - sub < 0 ? 0 : K - sub;
    var move = (int K, int sub) => K - sub < 0 ? K : sub;

    queue.Enqueue((A, B, C));

    while (queue.Count > 0)
    {
        (A, B, C) = queue.Dequeue();
        int toA = limit[0] - A, toB = limit[1] - B, toC = limit[2] - C;
        if (hs.Contains((A, B, C))) continue;
        hs.Add((A, B, C));
        
        if(A != 0)
        {
            queue.Enqueue((rest(A, toB), B + move(A, toB), C));
            queue.Enqueue((rest(A, toC), B, C + move(A, toC)));
        }

        if(B != 0)
        {
            queue.Enqueue((A + move(B, toA), rest(B, toA), C));
            queue.Enqueue((A, rest(B, toC), C + move(B, toC)));
        }

        if(C != 0)
        {
            queue.Enqueue((A + move(C, toA), B, rest(C, toA)));
            queue.Enqueue((A, B + move(C, toB), rest(C, toB)));
        }
    }
}