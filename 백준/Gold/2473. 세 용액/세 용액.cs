using static System.Math;

int gLength = int.Parse(Console.ReadLine());
var g = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

int l = 0, r = gLength - 1;
Answer ans = new Answer() { n = long.MaxValue };

Array.Sort(g);
for(; l < gLength - 2; l++)
{
    for(r = gLength - 1; r - l > 1; r--)
    {
        long sum = g[l] + g[r];
        long k = binaryMatch(-sum, l + 1, r - 1);
        sum += k;

        if (Abs(sum) < Abs(ans.n))
        {
            ans.n = sum;
            ans.nArr = new long[3] { g[l], g[r], k };
        }
    }
}

Array.Sort(ans.nArr);
Console.WriteLine($"{ans.nArr[0]} {ans.nArr[1]} {ans.nArr[2]}");

long binaryMatch(long n, int left, int right)
{
    int preLeft = left;
    int preRight = left;

    while (true)
    {
        int mid = (left + right) / 2;

        if (g[mid] == n)
        {
            return g[mid];
        }
        else if (g[mid] < n)
        {
            left = mid + 1;
        }
        else if (g[mid] > n)
        {
            right = mid - 1;
        }

        if (left > right)
        {
            long a = mid > preLeft ? Abs(g[mid - 1] - n) : long.MaxValue;
            long b = Abs(g[mid] - n);
            long c = mid < preRight ? Abs(g[mid + 1] - n) : long.MaxValue;

            long min = Min(a, Min(b, c));

            if(min == a) return g[mid - 1];
            if(min == b) return g[mid];
            if(min == c) return g[mid + 1];
        }
    }
}

struct Answer
{
    public long n;
    public long[] nArr;
}