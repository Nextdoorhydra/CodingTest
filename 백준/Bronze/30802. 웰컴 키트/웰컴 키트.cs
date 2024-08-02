using static System.Console;

int n = int.Parse(ReadLine());
var g = Array.ConvertAll(ReadLine().Split(), int.Parse);
var p = Array.ConvertAll(ReadLine().Split(), int.Parse);

int cnt = 0;
for (int i = 0; i < 6; i++) cnt += (g[i] % p[0] == 0 ? 0 : 1) + g[i] / p[0];

WriteLine($"{cnt}\n{n / p[1]} {n % p[1]}");