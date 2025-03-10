var ori_set = Console.ReadLine().Split().Select(int.Parse).ToList();
var vec = new (double, double)[ori_set.Count];
int ans = 0;

GetPermutations(ori_set, new List<int>());
Console.WriteLine(ans);

void GetPermutations(List<int> remaining, List<int> current)
{
    if (remaining.Count == 0)
    {
        if (CheckConvex(current))
            ans++;
        return;
    }

    for (int i = 0; i < remaining.Count; i++)
    {
        int num = remaining[i];
        var newRemaining = new List<int>(remaining);
        newRemaining.RemoveAt(i);

        var newCurrent = new List<int>(current) { num };

        GetPermutations(newRemaining, newCurrent);
    }
}

int CCW((double x, double y) p1, (double x, double y) p2, (double x, double y) p3)
{
    return Math.Sign(p1.x * p2.y + p2.x * p3.y + p3.x * p1.y - p2.x * p1.y - p3.x * p2.y - p1.x * p3.y);
}

bool CheckConvex(List<int> set)
{
    var bias = Math.PI / 4;

    for (int i = 0; i < 8; i++)
        vec[i] = (set[i] * Math.Cos(bias * i), set[i] * Math.Sin(bias * i));

    for (int i = 0; i < 8; i++)
        if (CCW(vec[i % 8], vec[(i + 1) % 8], vec[(i + 2) % 8]) < 0)
            return false;

    return true;
}