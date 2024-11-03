var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
const int MAX = 1_000_001;
int N = read()[0];
var data = read().ToHashSet();
var score = Enumerable.Repeat(0, MAX).ToList();

foreach(var x in data.OrderBy(x => x))
{
    for(int i = x + x; i < MAX; i += x)
    {
        if (data.Contains(i))
        {
            score[x]++;
            score[i]--;
        }
    }
}

Console.WriteLine(string.Join(' ', data.Select(x => score[x])));