int n = int.Parse(Console.ReadLine());
var seq = Console.ReadLine().Split().Select(long.Parse).ToList();

int l = 0, r = n - 1;
(long l, long r) ans = (seq[l], seq[r]);

while(l < r)
{
    long sum = seq[l] + seq[r], pre = ans.l + ans.r;
    if(Math.Abs(sum) < Math.Abs(pre))
    {
        ans = (seq[l], seq[r]);
    }

    if(sum == 0)
    {
        break;
    }
    else if (sum < 0)
    {
        l++;
    }
    else
    {
        r--;
    }
}

Console.WriteLine($"{ans.l} {ans.r}");