int n = int.Parse(Console.ReadLine());
var M = Enumerable.Repeat(long.MaxValue, n + 1).ToArray(); 

M[0] = 0;
for (int i = 1; i <= n; i++)
{
    for (int k = 1; k * k <= i; k++) M[i] = Math.Min(M[i - k * k] + 1, M[i]);
}

 Console.WriteLine(M[n]);