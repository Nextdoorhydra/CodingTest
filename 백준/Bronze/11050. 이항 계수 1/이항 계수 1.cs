var input = Console.ReadLine().Split().Select(int.Parse).ToList();
Console.WriteLine(Enumerable.Range(1, input[0]).getPartition(input[1]).Count());

static class extension
{
    public static IEnumerable<IEnumerable<T>> getPartition<T>(this IEnumerable<T> seq, int n)
    {
        if (n == 0)
        {
            yield return Enumerable.Empty<T>();
            yield break;
        }

        if (!seq.Any() || n > seq.Count())
        {
            yield break;
        }

        var first = seq.First();
        var remain = seq.Skip(1);

        foreach(var sub in getPartition(remain, n - 1))
        {
            yield return new[] { first }.Concat(sub);
        }
        foreach(var sub in getPartition(remain, n))
        {
            yield return sub;
        }
    }
}