int n = int.Parse(Console.ReadLine());
var g = new int[n, n];

for (int i = 0; i < n; i++)
{
    var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++) g[i, j] = input[j];
}

int[] ans = new int[2];
recur(new Vec { x = 0, y = 0 }, new Vec { x = n, y = n });

Console.WriteLine($"{ans[0]}\n{ans[1]}");

void recur(Vec from, Vec to)
{
    int color = g[from.x, from.y];

    var IsAllSameColor = bool (Vec from, Vec to) =>
    {
        int color = g[from.x, from.y];

        for (int r = from.x; r < to.x; r++)
        {
            for (int c = from.y; c < to.y; c++)
            {
                if (g[r, c] != color) return false;
            }
        }
        return true;
    };

    if (IsAllSameColor(from, to))
    {
        ans[color]++;
    }
    else
    {
        var half = (Vec v1, Vec v2) => new Vec { x = (v1.x + v2.x) / 2, y = (v1.y + v2.y) / 2 };

        recur(from, half(from, to));
        recur(half(from, to), to);
        recur(new Vec { x = from.x, y = half(from, to).y }, new Vec { x = half(from, to).x, y = to.y });
        recur(new Vec { x = half(from, to).x, y = from.y }, new Vec { x = to.x, y = half(from, to).y });
    }
}

public struct Vec
{
    public int x, y;
}