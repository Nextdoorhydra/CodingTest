Console.ReadLine();
int l = 0, r = 1, ans = 0;
var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

var g = input
    .Aggregate(new List<int>(), (ls, elem) =>
    {
        if (ls.Count > 0 && ls[ls.Count - 1] % 10 == elem)
        {
            ls[ls.Count - 1] += 10;
        }
        else
        {
            ls.Add(elem);
        }
        return ls;
    })
    .ToList();

var ToCount = (int x) => x / 10 + 1;
var ToNum = (int x) => x % 10;

int sum = g[l] / 10 + 1;
var log = new List<int>() { ToNum(g[l]), ToNum(g[g.Count != 1 ? r : 0])};

while (r < g.Count)
{
    if (log.Contains(ToNum(g[r])))
    {
        sum += ToCount(g[r]);
        r++;
    }
    else
    {
        l = r - 1;
        sum = ToCount(g[l]);

        log = new List<int>() { ToNum(g[l]), ToNum(g[r]) };
    }
    ans = Math.Max(ans, sum);
}

Console.WriteLine(ans > 0 ? ans : ToCount(g[0]));