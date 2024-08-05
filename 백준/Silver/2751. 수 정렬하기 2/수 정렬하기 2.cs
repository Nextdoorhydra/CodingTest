var g = new int[int.Parse(Console.ReadLine())];
for (int i = 0; i < g.Length; i++) g[i] = int.Parse(Console.ReadLine());

Console.WriteLine(string.Join("\n", g.OrderBy(x => x)));