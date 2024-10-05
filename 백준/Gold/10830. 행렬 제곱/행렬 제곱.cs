using static System.Linq.Enumerable;;
var read = () => Console.ReadLine().Split().Select(long.Parse).ToList();
var input = read();
var m = Range(0, (int)input[0]).Select(_ => read()).ToList();
int size = (int)input[0]; long n = input[1];
var I = Range(0, size).Select(i => Range(0, size).Select(j => i == j ? 1l : 0l).ToList()).ToList();

var dotProduct = (IEnumerable<long> rVec, IEnumerable<long> cVec) => rVec.Zip(cVec, (x, y) => x * y).Sum();
var mul = (List<List<long>> ma, List<List<long>> mb) =>
{
    var mab = Range(0, size).Select(_ => new List<long>()).ToList();
    for (int r = 0; r < size; r++)
        for (int c = 0; c < size; c++)
            mab[r].Add(dotProduct(ma[r], mb.Select(vec => vec.Skip(c).First())) % 1000);
    return mab;
};

while (n > 0)
{
    if (n % 2 == 1) I = mul(I, m);
    m = mul(m, m);
    n /= 2;
}

foreach (var vec in I) Console.WriteLine(string.Join(" ", vec));