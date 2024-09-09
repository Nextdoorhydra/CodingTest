long n = long.Parse(Console.ReadLine());
long k = long.Parse(Console.ReadLine());

long l = 1, m = 0, r = n * n, det;

while(l <= r)
{
    m = (l + r) / 2;
    det = getCount(m);

    if (det >= k)
    {
        if (getCount(m - 1) < k)
            break;
        r = m - 1;
    }
    else if (det < k)
    {
        l = m + 1;
    }
}

Console.WriteLine(m);

long getCount(long x)
{
    var clamp = (long x) => x > n ? n : x;
    long cnt = 0, sqrt = (long)Math.Sqrt(x);

    for(int i = 1; i <= sqrt; i++)
    {
        cnt += clamp(x / i) - i;
    }

    return 2 * cnt + sqrt;
}