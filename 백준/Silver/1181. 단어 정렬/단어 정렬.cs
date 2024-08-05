var g = new string[int.Parse(Console.ReadLine())];
for (int i = 0; i < g.Length; i++) g[i] = Console.ReadLine();

Console.WriteLine(string.Join("\n", 
    g.Distinct()
    .OrderBy(x => x.Length)
    .ThenBy(x => x)));