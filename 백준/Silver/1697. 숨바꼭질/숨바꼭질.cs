var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

if (input[0] == input[1])
{
    Console.WriteLine(0);
    return;
}

Func<int, bool> IsPassable = x => x >= 0 && x < 100001;
int N = input[0];
var map = new int[100001];

map[N] = -1;
map[input[1]] = 1;

Queue<(int, int)> Q = new Queue<(int, int)>();
Q.Enqueue((N, 0));

while (true)
{
    (int pos, int ans) now = Q.Dequeue();

    for(int i = 0; i < 3; i++)
    {
        int next = i switch { 0 => now.pos - 1, 1 => now.pos + 1, 2 => now.pos * 2 };

        if (IsPassable(next) && map[next] != -1)
        {
            if (map[next] == 1)
            {
                Console.WriteLine(++now.ans);
                return;
            }
            else
            {
                map[next] = -1;
                Q.Enqueue((next, now.ans + 1));
            }
        }
    }
}