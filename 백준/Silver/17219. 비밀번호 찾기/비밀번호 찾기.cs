StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

var n = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var g = new Dictionary<string, string>();

for (int i = 0; i < n[0]; i++)
{
    var input = sr.ReadLine().Split();
    g.Add(input[0], input[1]);
}

for(int i  = 0; i < n[1]; i++)
{
    sw.WriteLine(g[sr.ReadLine()]);
}

sr.Close();
sw.Close();