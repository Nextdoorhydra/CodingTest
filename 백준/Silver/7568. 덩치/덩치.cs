int n = int.Parse(Console.ReadLine());
var g = new (int w, int h)[n];

for(int i = 0; i < n; i++)
{
    var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    g[i] = (input[0], input[1]);
}

Console.WriteLine(string.Join(" ", g.Select(x => Rank(g, x)).ToArray()));

int Rank((int, int)[] arr, (int, int) n)
{
    int result = 1;
    foreach(var x in arr)
    {
        if (x.Item1 > n.Item1 && x.Item2 > n.Item2) result++;
    }
    return result;
}