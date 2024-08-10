using static System.Console;

int n = int.Parse(ReadLine());

while(n-- > 0)
{
    int k = int.Parse(ReadLine()), result = 0;
    var g = new List<(string, string)>();

    for (int j = 0; j < k; j++)
    {
        var get = ReadLine().Split();
        g.Add((get[1], get[0]));
    }

    WriteLine(g.GroupBy(x => x.Item1)
        .Select(x => x.Count() + 1)
        .Aggregate(1, (a, b) => a * b) - 1);
}