var ls = new List<int>();

for (int n = int.Parse(Console.ReadLine()); n > 0; n--)
{
    var c = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    if (c[0] > c[1]) (c[0], c[1], c[2], c[3]) = (c[1], c[0], c[3], c[2]);

    int year = c[3], gap = c[1] - c[0];
    (int, int) start = ((c[3] - 1) % c[0] + 1, c[3]);
    (int, int) end = (c[2], c[3]);

    for ((int, int) pos = start; pos != end; year += c[1])
    {
        pos = ((pos.Item1 + gap - 1) % c[0] + 1, pos.Item2);

        if (pos == start)
        {
            year = -1;
            break;
        }
    }
    ls.Add(year);
}

Console.WriteLine(string.Join("\n", ls));