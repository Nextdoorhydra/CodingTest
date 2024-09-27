int n = int.Parse(Console.ReadLine());
var g = Enumerable.Range(0, n).Select(_ => new List<(int to, int value)>()).ToList();

for(int i = 0; i < n - 1; i++)
{
    var input = Console.ReadLine().Split().Select(int.Parse).ToList();
    g[input[0]].Add((input[1], input[2]));
    g[input[1]].Add((input[0], input[3]));
}

var ratio = Enumerable.Range(0, n).Select(x => dfs(x)).ToList();
var div = ratio.Skip(1).Aggregate(ratio[0], (pre, x) => gcd(pre, x));
Console.WriteLine(string.Join(" ", ratio.Select(x => x / div)));

int gcd(int a, int b)
{
    if (a < b) (a, b) = (b, a);
    if (b == 0) return a;
    else return gcd(b, a % b);
}

int dfs(int start)
{
    Stack<int> to = new();
    var visited = new bool[n];
    int result = 1;

    to.Push(start);

    while(to.Count > 0)
    {
        int current = to.Pop();
        visited[current] = true;

        foreach(var next in g[current])
        {
            if (visited[next.to]) continue;
            result *= next.value;
            to.Push(next.to);
        }
    }

    return result;
}