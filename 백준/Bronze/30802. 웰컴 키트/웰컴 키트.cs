int n = int.Parse(Console.ReadLine());
var g = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var pair = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int cnt = 0;
for (int i = 0; i < g.Length; i++) cnt += (g[i] % pair[0] == 0 ? 0 : 1) + g[i] / pair[0];

Console.WriteLine($"{cnt}");
Console.WriteLine($"{n / pair[1]} {n % pair[1]}");
