using StreamWriter sw = new(Console.OpenStandardOutput());
int rep = Array.ConvertAll(Console.ReadLine().Split(), int.Parse)[1];
var seq = Console.ReadLine().Split().Select(int.Parse).ToList();

seq.Sort();
back(0, new List<int>());

void back(int depth, List<int> buf)
{
    if(depth == rep)
    {
        sw.WriteLine(string.Join(" ", buf));
        return;
    }

    for(int i = 0; i < seq.Count; i++)
    {
        if (buf.Contains(seq[i])) continue;
        back(depth + 1, buf.Append(seq[i]).ToList());
    }
}