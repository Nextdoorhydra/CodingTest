var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
var input = read();
int N = input[0], M = input[1];
var whoKnow = new bool[N + 1];
foreach (var i in read().Skip(1)) whoKnow[i] = true;
var parent = Enumerable.Range(0, N + 1).ToList();
var party = Enumerable.Range(0, M).Select(_ => read().Skip(1)).ToList();

for (int i = 0; i < M; i++)
    party[i].Skip(1).Aggregate(party[i].First(), (pre, x) => x + (whoKnow[find(pre)] ? union(pre, x) : union(x, pre)) * 0);
Console.WriteLine(party.Select(ls => ls.Select(x => whoKnow[find(x)]).All(x => x == false) ? 1 : 0).Sum());

int find(int x) => x == parent[x] ? x : parent[x] = find(parent[x]);
int union(int x, int y) => find(x) == find(y) ? -1 : parent[find(y)] = find(x);