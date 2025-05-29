using StreamWriter sw = new(Console.OpenStandardOutput());
var read = () => Console.ReadLine().Trim().Split().Select(long.Parse).ToList();
int N = (int)read()[0];
var V = Enumerable.Range(0, N).Select(_ => read().Skip(1).ToList()).ToList();

// boyerMooreMajority 
foreach (var v in V)
{
    int cnt = 1, half = v.Count() >> 1;
    long candiate = v[0];

    foreach (var i in v.Skip(1))
        if (i == candiate)
            ++cnt;
        else if (--cnt == 0)
        {
            candiate = i;
            cnt = 1;
        }

    sw.WriteLine(v.Where(x =>x == candiate).Count() > half ? candiate : "SYJKGW");
}