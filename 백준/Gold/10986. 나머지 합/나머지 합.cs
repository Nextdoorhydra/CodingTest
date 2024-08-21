var div = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var sum = Array.ConvertAll(Console.ReadLine().Split(), int.Parse)
    .Aggregate(new List<long>() { 0 }, (acc, x) =>
    {
        acc.Add(acc.Last() + x);
        return acc;
    })
    .Skip(1)
    .Select(x => x % div[1])
    .ToList();

var ans = new int[div[1]];
ans[0]++;
sum.ForEach(x => ans[x]++);

Console.WriteLine(ans.Select(x => (long)--x * (x + 1) / 2).Sum());