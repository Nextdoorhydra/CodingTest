var input = () => Console.ReadLine().Split().Select(int.Parse).ToList();
var A = input(); int V = A[0], E = A[1];
List<long> MST = new();
var set = Enumerable.Range(0, V + 1).ToList();
var edgeList = Enumerable.Range(0, E).Select(_ => input()).ToList().OrderBy(x => x.Last()).ToList();

int find(int x) => set[x] == x ? x : set[x] = find(set[x]);
var union = (int x, int y) => find(x) != find(y) ? (set[find(x)] = find(y), true) : (0, false);

while (true)
{
    foreach (var edge in edgeList)
    {
        if (MST.Count == V - 1)
        {
            Console.WriteLine(MST.Sum());
            return;
        }

        if (union(edge[0], edge[1]).Item2) MST.Add(edge[2]);
    }
}