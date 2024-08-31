var input = () => Console.ReadLine();
int rep = int.Parse(input());

for(int i = 0; i < rep; i++)
{
    solve(int.Parse(input()));
}

void solve(int n)
{
    var ls = new List<List<int>>();
    var sw = (int x) => x switch { 0 => 1, _ => 0 };

    for(int i = 0; i < 2; i++) ls.Add(input().Split().Select(int.Parse).ToList());

    if(n != 1)
    {
        ls[0][1] += ls[1][0];
        ls[1][1] += ls[0][0];

        for (int i = 2; i < n; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                ls[j][i] += Math.Max(Math.Max(ls[0][i - 2], ls[1][i - 2]),
                    ls[sw(j)][i - 1]);
            }
        }
    }

    Console.WriteLine(ls.Select(x => x.Max()).Max());
}