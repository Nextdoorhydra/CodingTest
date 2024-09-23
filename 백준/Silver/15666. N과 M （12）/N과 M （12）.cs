using StreamWriter sw = new(Console.OpenStandardOutput());

int M = Console.ReadLine().Split().Select(int.Parse).Last();
var seq = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToList();

HashSet<string> hs = new();
back(new List<int>());

foreach(var s in hs) 
    sw.WriteLine(s);

void back(List<int> sel, int idx = 0, int depth = 0)
{
    if(depth == M)
    {
        var check = string.Join(" ", sel);

        if (!hs.Contains(check))
            hs.Add(check);
        return;
    }

    for(int i = idx; i < seq.Count; i++)
        back(sel.Append(seq[i]).ToList(), i, depth + 1);
}