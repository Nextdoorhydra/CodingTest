int n = int.Parse(Console.ReadLine());
var g = new (int x, int y)[n];

for(int i = 0; i < n; i++)
{
    var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    g[i] = (input[0], input[1]);
}

var ans = from xy in g
          orderby xy.x, xy.y
          select xy;

Console.WriteLine(string.Join("\n", ans.Select(x => $"{x.x} {x.y}")));