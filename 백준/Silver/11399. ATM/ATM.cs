var g = new int[int.Parse(Console.ReadLine())];
g = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); Array.Sort(g);

int sum = 0;
var memo = new int[1000];

memo[0] = g[0];

for(int i = 1; i< g.Length; i++) memo[i] = memo[i - 1] + g[i];

Console.WriteLine(memo.Take(g.Length).Sum());