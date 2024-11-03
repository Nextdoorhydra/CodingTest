var read = () => Console.ReadLine();
var input = read().Split().Select(int.Parse).ToList();
int R = input[0], C = input[1], ANSWER = 0;
var map = Enumerable.Range(0, R).Select(_ => read().ToCharArray().ToList()).ToList();
var memo = Enumerable.Range(0, R).Select(_ => Enumerable.Range(0, C).Select(_ => new HashSet<string>()).ToList()).ToList();
var move = new Func<int, int, (int r, int c)>[]
{
    (r, c) => ((r + 1, c)),
    (r, c) => ((r - 1, c)),
    (r, c) => ((r, c + 1)),
    (r, c) => ((r, c - 1))
};
var isMovable = (int r, int c) => r >= 0 && c >= 0 && r < R && c < C;
dfs(0, 0, new HashSet<char>() { map[0][0] });
Console.WriteLine(ANSWER);

void dfs(int r, int c, HashSet<char> buf)
{
    foreach (var m in move)
    {
        int nr = m(r, c).r, nc = m(r, c).c;
        if (isMovable(nr, nc) 
            && !buf.Contains(map[nr][nc]) 
            && !memo[nr][nc].Contains(new string(buf.Append(map[nr][nc]).ToArray())))
        {
            dfs(nr, nc, buf.Append(map[nr][nc]).ToHashSet());
        }
        memo[r][c].Add(new string(buf.ToArray()));
    }
    ANSWER = Math.Max(ANSWER, buf.Count());
}