var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
Queue<int> queue = new Queue<int>();
int N = read()[0], now;
List<int> inorder = Enumerable.Repeat(0, N + 1).ToList(), lapsed = inorder.ToList(), times = inorder.ToList();
var edgeList = inorder.Select(_ => new List<int>()).ToList();

for (int i = 1; i <= N; i++)
{
    var input = read();
    times[i] = input[0];
    foreach (var next in input.Take(input.Count() - 1).Skip(1))
    {
        inorder[i]++;
        edgeList[next].Add(i);
    }
}

for (int i = 1; i <= N; i++) if (inorder[i] == 0) queue.Enqueue(i);

while (queue.Count > 0)
{
    now = queue.Dequeue();
    times[now] += lapsed[now];

    foreach (var next in edgeList[now])
    {
        if (--inorder[next] == 0) queue.Enqueue(next);
        lapsed[next] = Math.Max(times[now], lapsed[next]);
    }
}

Console.WriteLine(string.Join(" ", times.Skip(1)));