using System.Runtime.Intrinsics;

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
v = v.Skip(1).OrderBy(v => (v.x - v0.x, v.y - v0.y), new AngleComparer()).ToList();

pripara.Push(v0);
pripara.Push(v[0]);

var ccw = ((long x, long y) v1, (long x, long y) v2, (long x, long y) v3)
    => v1.x * v2.y + v2.x * v3.y + v3.x * v1.y - v2.x * v1.y - v3.x * v2.y - v1.x * v3.y;
var norm =((long x, long y) v) => v.x * v.x + v.y * v.y;

for (int i = 1; i < v.Count; i++)
{
    var v2 = pripara.Pop();
    var v1 = pripara.Pop();
    var v3 = v[i];
    pripara.Push(v1);

    var det = ccw(v1, v2, v3);

    if (det > 0)
    {
        pripara.Push(v2);
        pripara.Push(v3);
    }
    else if (det < 0)
    {
        i--;
    }
    else
    {
        (long x, long y) dv2 = (v2.x - v1.x, v2.y - v1.y);
        (long x, long y) dv3 = (v3.x - v1.x, v3.y - v1.y);
        pripara.Push(norm(dv2) > norm(dv3) ? v2 : v3);
    }
}

var last = pripara.Pop();
if (ccw(v0, last, pripara.Peek()) != 0)
    pripara.Push(last);


Console.WriteLine(pripara.Count);

public class AngleComparer : IComparer<(long x, long y)>
{
    public int Compare((long x, long y) v1, (long x, long y) v2)
    {
        var det = v1.x * v2.y - v1.y * v2.x;

        if (det > 0)
        {
            return -1;
        }
        else if (det == 0)
        {
            if(v1.y != v2.y) return v1.y < v2.y ? -1 : 1;
            else return v1.x < v2.x ? -1 : 1;
        }
        else
        {
            return 1;
        }
    }
}