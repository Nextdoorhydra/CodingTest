var div = Console.ReadLine().Split().Select(int.Parse).ToList()[1];
var seq = Console.ReadLine().Split().Select(int.Parse).ToList();
var orderedSeq = seq.OrderBy(x => x).ToList();
var sum = seq.Aggregate(new List<int>() { 0 }, (acc, x) =>
{
    acc.Add(x + acc[^1]);
    return acc;
}).Skip(1).ToList();

int l = orderedSeq[^1], r = sum[^1];
int answer = 0;

while(l <= r)
{
    int target = (l + r) / 2;

    if (IsDivided(target))
    {
        answer = target;
        r = target - 1;
    }
    else
    {
        l = target + 1;
    }
}

Console.WriteLine(answer);

bool IsDivided(int target)
{
     int cnt = 0, offset = 0;

    for(int i = 1; i < sum.Count; i++)
    {
        if (sum[i] > target + offset)
        {
            cnt++; offset = sum[i - 1];
        }
    }

    if (cnt + 1 <= div) return true; else return false;
}