var seq = Enumerable.Range(0, int.Parse(Console.ReadLine()))
    .Select(_ => int.Parse(Console.ReadLine()))
    .OrderBy(x => x).ToList();
var lower = seq.TakeWhile(x => x <= 0).ToList();
var upper = seq.Skip(lower.Count).Reverse().ToList();

var f = (List<int> seq) =>
{
    var sum = ((int l, int r) n) => n switch
    {
        ( <= 0, <= 0) or ( > 1, > 1) => n.l * n.r,
        _ => n.l + n.r
    };

    return Enumerable.Range(0, (seq.Count + 1) / 2)
    .Select(i => seq.Skip(i * 2).Take(2))
    .Select(x => x.Count() < 2 ? x.First() : sum((x.First(), x.Last()))).Sum();
};

Console.WriteLine(f(lower) + f(upper));