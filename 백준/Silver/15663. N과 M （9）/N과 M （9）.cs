using StreamWriter sw = new(Console.OpenStandardOutput());
var rep = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var seq = Console.ReadLine().Split().Select(int.Parse).ToList();

seq.Sort();
back(0, seq, new List<int>());


void back(int depth, List<int> seq, List<int> buf)
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
            if (hs.Contains(seq[i]) || seq[i] == -1) continue;

            hs.Add(seq[i]);
            var nextSeq = new List<int>(seq);
            nextSeq[i] = -1;
            back(depth + 1, nextSeq, buf.Append(seq[i]).ToList());
        }
    }
}