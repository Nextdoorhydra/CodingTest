var prime = Enumerable.Range(0, 1_000_000 + 1).Select(x => (long)x).ToList();

for (int i = 2; i < prime.Count; i++)
{
    if (prime[i] == 0) continue;
    for (int j = i + i; j < prime.Count; j += i) prime[j] = 0;
}

prime = prime.Skip(2).Where(x => x != 0).Select(x => x * x).ToList();

var input = Console.ReadLine().Split().Select(long.Parse).ToList();
long min = input[0], max = input[1], ANSWER = max - min + 1;
var hs = new HashSet<long>();

foreach (var x in prime)
{
    long cnt = min / x;
    while(x * cnt <= max)
    {
        if (x * cnt >= min && !hs.Contains(x * cnt)) hs.Add(x * cnt);
        cnt++;
    }
}

Console.WriteLine(ANSWER - hs.Count());