var div = Console.ReadLine().Split().Select(int.Parse).ToList()[1];
var seq = Console.ReadLine().Split().Select(int.Parse).ToList();
var sum = seq.Aggregate(new List<int>() { 0 }, (acc, x) =>
{
    acc.Add(x + acc[^1]);
    return acc;
}).Skip(1).ToList();

int l = seq.Max(), r = sum[^1], ANS = 0;

while(l <= r)
{
    int target = (l + r) / 2;

    if (IsDivided(target))
    {
        ANS = target;
        r = target - 1;
    }
    else
    {
        l = target + 1;
    }
}

Console.WriteLine(ANS);

bool IsDivided(int target)
{
     int cnt = 1, offset = 0;

    for(int i = 1; i < sum.Count; i++)
        if (sum[i] > target + offset)
        {
            cnt++; offset = sum[i - 1];
        }

    if (cnt <= div) return true; else return false;
}