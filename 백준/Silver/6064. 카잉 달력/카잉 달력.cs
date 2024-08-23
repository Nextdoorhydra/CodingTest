var ls = new List<int>();

for(int n = int.Parse(Console.ReadLine()); n > 0; n--)
{
    var c = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    if (c[0] > c[1]) (c[0], c[1], c[2], c[3]) = (c[1], c[0], c[3], c[2]);

    var table = Enumerable.Range(1, c[1]).Select(x => ((x - 1) % c[0] + 1, x)).ToList();

    (int, int) start = table[c[3] - 1];
    (int, int) end = (c[2], c[3]);
    (int, int) current = start;
    int year = c[3], gap = c[1] - c[0];

    while(current != end)
    {

        year += c[1];
        current = ((current.Item1 + gap - 1) % c[0] + 1, current.Item2);

        if (current == start)
        {
            year = -1;
            break;
        }
    }

    ls.Add(year);
}

Console.WriteLine(string.Join("\n", ls));