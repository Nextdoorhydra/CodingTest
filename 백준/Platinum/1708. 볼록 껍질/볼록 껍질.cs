int rep = int.Parse(Console.ReadLine());
var v = new List<(long x, long y)>();
var pripara = new Stack<(long x, long y)>();


for (int i = 0; i < rep; i++)
{
    var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
    v.Add((input[0], input[1]));
}

v = v.OrderBy(v => v.y).ThenBy(v => v.x).ToList();
var v0 = v[0];
v = v.Skip(1).OrderBy(v => (v.x - v0.x, v.y - v0.y), new AngleComparer())
    .ThenBy(v => v.y)
    .ThenBy(v => v.x)
    .ToList();

var ccw = ((long x, long y) v1, (long x, long y) v2, (long x, long y) v3)
    => v1.x * v2.y + v2.x * v3.y + v3.x * v1.y - v2.x * v1.y - v3.x * v2.y - v1.x * v3.y;

pripara.Push(v0);
pripara.Push(v[0]);

for(int i = 1; i < rep - 1; i++)
{
    while(pripara.Count >= 2)
    {
        var laala = pripara.Pop();
        var mirei = pripara.Peek();

        if (ccw(v[i], laala, mirei) < 0)
        {
            pripara.Push(laala);
            break;
        }
    }

    pripara.Push(v[i]);
}

Console.WriteLine(pripara.Count);

public class AngleComparer : IComparer<(long x, long y)>
{
    public int Compare((long x, long y) v1, (long x, long y) v2)
    {
        var det = v1.y * v2.x - v1.x * v2.y;

        return Math.Sign(det);
    }
}