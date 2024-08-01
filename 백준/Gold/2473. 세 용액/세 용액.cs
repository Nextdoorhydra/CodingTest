int size = int.Parse(Console.ReadLine());
var g = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

var min = long.MaxValue;
(int i, int l, int r) ans = (g[0], g[1], g[2]);

Array.Sort(g);

for (int i = 0; i < size - 2; i++)
{
    int l = i + 1;
    int r = size - 1;

    while(l < r)
    {
        long sum = (long)g[i] + g[l] + g[r];

        var S = Math.Abs(sum);
        if (S < min)
        {
            min = S;
            ans = (g[i], g[l], g[r]);
        }

        if (sum == 0) goto OUT;
        if (sum > 0) r--;
        if (sum < 0) l++;
    }
}

OUT: Console.WriteLine($"{ans.i} {ans.l} {ans.r}");