using StreamWriter sw = new(Console.OpenStandardOutput());
var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();

var input = read();
int N = input[0], R = input[1], Q = input[2];
var visited = new bool[N + 1];
var count = new int[N + 1];
var edgeList = Enumerable.Range(0, N + 1).Select(_ => new List<int>()).ToList();

//get edge
for (int i = 1; i < N; i++)
{
    input = read();
    edgeList[input[0]].Add(input[1]);
    edgeList[input[1]].Add(input[0]);
}

visited[R] = true;
dfs(R);

//query
for (int i = 0; i < Q; i++)
    sw.WriteLine(count[read()[0]]);

void dfs(int idx)
{
    count[idx] = 1;
    foreach (var next in edgeList[idx])
    {
        if (visited[next]) continue;
        visited[next] = true;
        dfs(next);
        count[idx] += count[next];
    }
}