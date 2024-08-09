using System.Collections.Immutable;

var max = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var g = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

Array.Sort(g);

long l = 0, r = g[^1], m;

while(l <= r)
{
    m = (l + r) / 2;
    long sum = g.Sum(x => x - m >= 0 ? x - m : 0);

    if(sum > max[1])
    {
        l = m + 1;
    }
    else if(sum < max[1])
    {
        r = m - 1;
    }
    else
    {
        r = m;
        break;
    }
}

Console.WriteLine(r);