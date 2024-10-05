using StreamWriter sw = new(Console.OpenStandardOutput());
var read = () => Console.ReadLine().Split().Select(long.Parse).ToList();
var printMatrix = (List<List<long>> m) => { foreach (var vec in m) sw.WriteLine(string.Join(" ", vec)); };
var input = read();
printMatrix(matrixPower(Enumerable.Range(0, (int)input[0]).Select(_ => read()).ToList(), (int)input[0], input[1]));

List<List<long>> matrixPower(List<List<long>> m, int size, long n)
{
    var I = Enumerable.Range(0, size).Select(i => Enumerable.Range(0, size).Select(j => i == j ? 1l : 0l).ToList()).ToList();

    var mul = (List<List<long>> ma, List<List<long>> mb) =>
    {
        var mab = Enumerable.Range(0, size).Select(_ => new List<long>()).ToList();
        var dotProduct = (IEnumerable<long> rVec, IEnumerable<long> cVec) => rVec.Zip(cVec, (x, y) => x * y).Sum();
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
    return I;
}