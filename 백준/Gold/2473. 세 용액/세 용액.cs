int gLength = int.Parse(Console.ReadLine());
var g = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

long min = long.MaxValue;
long[] ans = new long[3] { g[0], g[1], g[2] };

Array.Sort(g);

for (int i = 0; i < gLength - 2; i++)
{
    int l = i + 1;
    int r = gLength - 1;

    while(l < r)
    {
        long sum = g[i] + g[l] + g[r];

        var S = Math.Abs(sum);
        if (S < min)
        {
            min = S;
            ans = new long[3] { g[i], g[l], g[r] };
        }

        if (sum == 0) goto OUT;
        if (sum > 0) r--;
        if (sum < 0) l++;
    }
}

OUT: Console.WriteLine($"{ans[0]} {ans[1]} {ans[2]}");