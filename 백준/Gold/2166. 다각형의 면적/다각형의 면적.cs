var CCW = (List<double> A, List<double> B) => 0.5 * (A[1] * B[2] - A[2] * B[1] + A[2] * B[0] - A[0] * B[2] + A[0] * B[1] - A[1] * B[0]);

var input = Enumerable.Range(1, int.Parse(Console.ReadLine()))
    .Select(x => Console.ReadLine().Split().Select(double.Parse).Append(0).ToList()).ToList();
var ls = input.Skip(1).Select(x => x.Zip(input[0], (x, y) => x - y).ToList()).ToList();
Console.WriteLine($"{Math.Abs(ls.Skip(1).Aggregate((pre: ls[0], sum: 0d), (acc, x) => (x, acc.sum + CCW(x, acc.pre))).sum):F1}");