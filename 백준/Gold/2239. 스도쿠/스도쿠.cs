List<List<int>> map = new();
var check = Enumerable.Range(0, 10)
    .Select(_ => (rowCheck: new HashSet<int>(), colCheck: new HashSet<int>())).ToList();
var box = Enumerable.Range(0, 9).Select(_ => new HashSet<int>()).ToList();
var mapping = ((int r, int c) x) => x switch
{
    (< 3, < 3) => 0, (< 3, < 6) => 1, (< 3, < 9) => 2,
    (< 6, < 3) => 3, (< 6, < 6) => 4, (< 6, < 9) => 5,
    (< 9, < 3) => 6, (< 9, < 6) => 7, _ => 8
};
var update = (int n, int r, int c) =>
{
    check[n].rowCheck.Add(r);
    check[n].colCheck.Add(c);
    box[mapping((r, c))].Add(n);
};
var reset = (int n, int r, int c) =>
{
    check[n].rowCheck.Remove(r);
    check[n].colCheck.Remove(c);
    box[mapping((r, c))].Remove(n);
};

for (int r = 0; r < 9; r++)
{
    var input = Console.ReadLine().Select(x => x - '0').ToList();

    for (int c = 0; c < 9; c++)
    {
        if (input[c] == '0') continue;
        update(input[c], r, c);
    }

    map.Add(input);
}
back();

bool back(int r = 0, int c = 0)
{
    if (r == 9)
    {
        map.ForEach(x => Console.WriteLine(string.Join("", x)));
        return true;
    }

    if (map[r][c] != 0)
    {
        if(back(r + (c + 1) / 9, (c + 1) % 9)) return true;
    }
    else
    {
        for(int n = 1; n <= 9; n++)
        {
            if (!check[n].rowCheck.Contains(r) && !check[n].colCheck.Contains(c) && !box[mapping((r, c))].Contains(n))
            {
                update(n, r, c);
                map[r][c] = n;

                if(back(r + (c + 1) / 9, (c + 1) % 9)) return true;

                reset(n, r, c);
                map[r][c] = 0;
            }
        }
    }

    return false;
}