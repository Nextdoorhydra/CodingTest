int n = int.Parse(Console.ReadLine());
var ls = new List<List<int>>();
while(n-- > 0) ls.Add(Console.ReadLine().Split().Select(int.Parse).ToList());

for(int i = 1; i < ls.Count; i++)
{
    for (int j = 0; j < ls[i].Count; j++)
    {
        if (j == 0) ls[i][0] += ls[i - 1][0];
        else if(j == ls[i].Count - 1) ls[i][j] += ls[i - 1][j - 1];
        else
        {
            ls[i][j] += Math.Max(ls[i - 1][j - 1], ls[i - 1][j]);
        }
    }
}

Console.WriteLine(ls[^1].Max());