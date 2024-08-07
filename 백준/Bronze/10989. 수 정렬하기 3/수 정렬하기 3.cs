StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

int n = int.Parse(sr.ReadLine());
var g = new int[10_001];

for(int i = 0; i < n; i++)
{
    g[int.Parse(sr.ReadLine())]++;
}

for(int i = 0; i < g.Length; i++)
{
    while (g[i]-- > 0) sw.WriteLine(i);
}

sr.Close();
sw.Close();