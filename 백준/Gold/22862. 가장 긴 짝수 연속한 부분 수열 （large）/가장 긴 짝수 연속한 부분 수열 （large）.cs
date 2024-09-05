var k = Console.ReadLine().Split().Select(int.Parse).Last();
var IsEven = (int n) => n % 2 == 0;
var seq = Console.ReadLine().Split().Select(int.Parse)
    .SkipWhile(x => !IsEven(x))
    .Aggregate((acc: new List<(int N, int weight)>(), LastState: "ODD"), (state, x) =>
    {
        var (acc, LastState) = state;

        if (IsEven(x))
        {
            if (LastState == "ODD") acc.Add((0, 0));

            LastState = "EVEN";
            acc[^1] = (acc[^1].N + 1, acc[^1].weight);
        }
        else
        {
            LastState = "ODD";
            acc[^1] = (acc[^1].N, acc[^1].weight + 1);
        }

        return (acc, LastState);
    }).acc;

int sum = seq.Count > 0 ? seq[0].N : 0, max = sum, from = 0;

for (int to = 1; to < seq.Count && sum > 0; to++)
{
    if (seq[to - 1].weight <= k)
    {
        k -= seq[to - 1].weight;
        sum += seq[to].N;
    }
    else
    {
        k += seq[from].weight;
        sum -= seq[from].N;

        to--;
        from++;
    }
    max = Math.Max(max, sum);
}

Console.WriteLine(max);