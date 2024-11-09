var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
int R = read()[0];
while (R-- > 0)
{
    Queue<(int pr, bool M)> q = new();
    var input = read();
    var seq = read().Select((x, idx) => idx == input[1] ? (x, true) : (x, false)).ToList();
    int N = input[0], ans = 0;
    seq.ForEach(x => q.Enqueue(x));

    while(q.Count > 0)
    {
        ans++;
        var x = q.Dequeue();

        if (q.Count == 0 || x.pr >= q.Max(x => x.pr))
        {
            if (x.M)
            {
                Console.WriteLine(ans);
                break;
            }
        }
        else
        {
            ans--;
            q.Enqueue(x);
        }
    }
}