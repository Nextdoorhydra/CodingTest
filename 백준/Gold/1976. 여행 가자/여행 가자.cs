var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
int N = read()[0], M = read()[0];
var adjacentList = Enumerable.Range(0, N).Select(_ => read()).ToList();
var plan = read().Select(x => x - 1).ToList();

var set = Enumerable.Range(0, N).ToList();
int find(int a) => set[a] == a ? a : set[a] = find(set[a]);
int union(int a, int b) => find(a) == find(b) ? -1 : set[find(b)] = find(a);

for (int i = 0; i < N; i++)
    for (int j = 0; j < N; j++)
        if (adjacentList[i][j] == 1) union(i, j);

int idx = find(plan[0]);
var answer = true;
for(int i = 1; i < M; i++)
{
    if(idx != find(plan[i]))
    {
        answer = false;
        break;
    }
}

Console.WriteLine(answer ? "YES" : "NO");