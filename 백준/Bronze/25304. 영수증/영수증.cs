using static System.Console;
int price = int.Parse(ReadLine()), rep = int.Parse(ReadLine());

WriteLine(Enumerable.Range(0, rep)
    .Select(_ => ReadLine().Split().Select(int.Parse).ToList())
    .Select(ls => ls[0] * ls[1]).Sum() == price ? "Yes" : "No");