using System.Numerics;

int n = int.Parse(Console.ReadLine());
var g = new BigInteger[1000];

g[0] = 1; g[1] = 2;

for(int i = 2; i < n; i++) g[i] = g[i - 1] + g[i - 2];

Console.WriteLine(g[n - 1] % 10007);