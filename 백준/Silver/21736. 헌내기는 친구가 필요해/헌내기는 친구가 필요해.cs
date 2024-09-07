var input = Console.ReadLine().Split().Select(int.Parse).ToList();
int N = input[0], M = input[1], answer = 0;
var visited = new bool[N, M];
var map = new char[N, M];

for (int i = 0; i < N; i++)
{
    var _input = Console.ReadLine().ToCharArray();
    for (int j = 0; j < M; j++) map[i, j] = _input[j];
}

var IsPassable = (int n, int m) => n < N && m < M && n >= 0 && m >= 0;
var move = new Func<int, int, (int x, int y)>[] { (x, y) => (x + 1, y), (x, y) => (x, y + 1), (x, y) => (x - 1, y), (x, y) => (x, y - 1)  };

for(int i = 0; i < N; i++) 
    for (int j = 0; j < M; j++) 
        if (map[i, j] == 'I')
        {
            dfs(i, j);
            goto OUT;
        }

OUT: Console.WriteLine(answer switch { 0 => "TT", _ => answer });

void dfs(int n, int m)
{
    if(IsPassable(n, m) && !visited[n, m] && map[n, m] != 'X')
    {
        visited[n, m] = true;

        if (map[n, m] == 'P') answer++;

        foreach (var f in move)
        {
            (int ToN, int ToM) = f(n, m);
            dfs(ToN, ToM);
        }
    }
}