var input = read();
int N = input[0], M = input[1], ANSWER = 0, latest = 0;
var parent = Enumerable.Range(0, N + 1).ToList();
var edges = Enumerable.Range(0, M).Select(_ => read()).OrderBy(x => x.Last());

foreach(var edge in edges) if (union(edge[0], edge[1]) != -1) ANSWER += (latest = edge[2]);
Console.WriteLine(ANSWER - latest);

List<int> read() => Console.ReadLine().Split().Select(int.Parse).ToList();
int find(int x) => x == parent[x] ? x : parent[x] = find(parent[x]);
int union(int x, int y) => find(x) == find(y) ? -1 : parent[find(y)] = find(x);