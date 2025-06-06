var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
var input = read();
int N = input[0], M = input[1], turn = 0, flag = 0;
var edgeList = Enumerable.Range(0, M).Select(_ => read()).ToList();
var parent = Enumerable.Range(0, N + 1).ToList();

foreach (var edge in edgeList)
{
    turn++;
    if (union(edge.First(), edge.Last()) == -1) { flag = 1; break; }
}

Console.WriteLine(flag < 1 ? 0 : turn);

int find(int x) => x == parent[x] ? x : parent[x] = find(parent[x]);
int union(int x, int y) => find(x) == find(y) ? -1 : parent[find(y)] = find(x);