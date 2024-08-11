var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

var map = Enumerable.Range(0, 99).ToArray();
var visited = new bool[100];

for (int i = 0; i < input.Sum(); i++)
{
    var get = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    map[get[0] - 1] = get[1] - 1;
}

Queue<(int, int)> Q = new Queue<(int, int)>();
Q.Enqueue((0, 0));
visited[0] = true;

while (true)
{
    (int pos, int ans) now = Q.Dequeue();

    for (int i = 1; i <= 6; i++)
    {
        if (now.pos + i < 99)
        {
            if(!visited[map[now.pos + i]])
            {
                visited[map[now.pos + i]] = true;
                Q.Enqueue((map[now.pos + i], now.ans + 1));
            }
        }
        else
        {
            Console.WriteLine(now.ans + 1);
            return;
        }
    }
}