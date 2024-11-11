var read = () => double.Parse(Console.ReadLine());

var N = read();
var ls = Enumerable.Range(0, (int)N).Select(_ => read()).OrderBy(x => x).ToList();
Dictionary<double, int> dic = new();

int max = 0;
ls.ForEach(x =>
{
    if (!dic.ContainsKey(x))
    {
        dic.Add(x, 1);
    }
    else
    {
        dic[x]++;
    }

    max = Math.Max(max, dic[x]);
});

var mode = dic.Keys.Where(x => dic[x] == max).OrderBy(x => x).ToList();
var mean = Math.Round(ls.Sum() / N);
Console.WriteLine(mean == -0 ? 0 : mean);
Console.WriteLine(ls[(int)N / 2]);
Console.WriteLine(mode.Count > 1 ? mode[1] : mode[0]);
Console.WriteLine(Math.Abs(ls.First() - ls.Last()));