int N = int.Parse(Console.ReadLine()), l = 0, r = 0, ans = 0, sum = 2;
var prime = Enumerable.Range(0, 4000001).ToList();

prime[1] = 0;
for (int i = 2; i * i < 4000001; i++)
{
    if (prime[i] == 0) continue;

    for (int j = i * i; j < 4000001; j += i)
    {
        prime[j] = 0;
    }
}

prime = prime.Where(x => x != 0).ToList();

while (l <= r)
{
    if (sum < N)
    {
        r++;
        try
        {
            sum += prime[r];
        }
        catch (Exception)
        {
            break;
        }
    }
    else if (sum >= N)
    {
        if(sum == N) ans++;
        sum -= prime[l];
        l++;
    }
}

Console.WriteLine(ans);