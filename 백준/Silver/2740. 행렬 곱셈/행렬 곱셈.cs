using StreamWriter sw = new(Console.OpenStandardOutput());
var matrixMultiple = (List<List<int>> ma, List<List<int>> mb) =>
{
    if (ma.First().Count != mb.Count) 
        throw new Exception();

    var innerProduct = (IEnumerable<int> rVec, IEnumerable<int> cVec) => rVec.Zip(cVec, (x, y) => x * y).Sum();
    int r = ma.Count, c = mb.First().Count;
    var m = Enumerable.Range(0, r).Select(_ => new List<int>()).ToList();

    for(int i = 0; i < r; i++)
        for(int j = 0; j < c; j++)
            m[i].Add(innerProduct(ma[i], mb.Select(vec => vec.Skip(j).First())));
    return m;
};

var input = () => Enumerable.Range(0, int.Parse(Console.ReadLine().Split().First()))
    .Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList()).ToList();

var ma = input(); var mb = input();
matrixMultiple(ma, mb).ForEach(x => sw.WriteLine(string.Join(" ", x)));