using System.Text;

var sb = new StringBuilder();
var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

var IsValid = (int mask, int n) => (mask & (1 << n)) != 0;
var count = (int mask) =>
{
    int cnt = 0;
    for (int i = 1; i <= 8; i++) if (IsValid(mask, i)) cnt++;
    return cnt;
};
var maskToString = (int mask) =>
{
    var ans = new List<int>();
    for(int i = 1; i <= 8; i++) if (IsValid(mask, i)) ans.Add(i);
    return string.Join(" ", ans);
};

void back(int max, int length, int n = 0, int mask = 0)
{
    if (n > max) return;

    if (!IsValid(mask, n))
    {
        mask |= (1 << n);
    }

    if (count(mask) == length)
    {
        sb.AppendLine(maskToString(mask));
    }
    else
    {
        for(int i = 1; i <= max; i++)
        {
            back(max, length, n + i, mask);
        }
    }
}

back(input[0], input[1]);
Console.WriteLine(sb);