int n = int.Parse(Console.ReadLine()), time = 0, count = 0;
var table = new List<(int start, int end)>();

for(int i = 0; i < n; i++)
{
    var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    table.Add((input[0], input[1]));
}

table = table.OrderBy(x => x.end).ThenBy(x => x.start).ToList();

for(int i = 0; i < n; i++)
{
    if (time > table[i].start) continue;
    time = table[i].end;
     count++;
}

Console.WriteLine(count);