using static System.Linq.Enumerable;;
var read = () => Console.ReadLine().Split().Select(long.Parse).ToList();
var input = read();
var m = Range(0, (int)input[0]).Select(_ => read()).ToList();
int L = (int)input[0];
var I = Range(0, L).Select(i => Range(0, L).Select(j => i == j ? 1l : 0l).ToList()).ToList();

var mul = (List<List<long>> ma, List<List<long>> mb) =>
{
    var mab = Range(0, L).Select(_ => new List<long>()).ToList();
    for (int r = 0; r < L; r++) for (int c = 0; c < L; c++) mab[r].Add(ma[r].Zip(mb.Select(vec => vec.Skip(c).First()), (x, y) => x * y).Sum() % 1000);
    return mab;
};

for(var n = input[1]; n > 0 ; n /= 2)
{
    if (n % 2 == 1) I = mul(I, m);
    m = mul(m, m);
}

foreach (var vec in I) Console.WriteLine(string.Join(" ", vec));