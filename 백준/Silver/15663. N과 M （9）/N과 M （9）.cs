using StreamWriter sw = new(Console.OpenStandardOutput());
var rep = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var seq = Console.ReadLine().Split().Select(int.Parse).ToList();
var visited = new bool[rep[0]];

seq.Sort();
back(0, new List<int>());

void back(int depth, List<int> buf)
{
    if (depth == rep[1])
    {
        sw.WriteLine(string.Join(" ", buf));
        return;
    }
    else
    {
        var hs = new HashSet<int>();

        for (int i = 0; i < seq.Count; i++)
        {
            if (hs.Contains(seq[i]) || visited[i]) continue;

            hs.Add(seq[i]);
            visited[i] = true;
            back(depth + 1, buf.Append(seq[i]).ToList());
            visited[i] = false;
        }
    }
}