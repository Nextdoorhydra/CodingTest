var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();

var input = read();
int N = input[0], now;
List<int> inorder = Enumerable.Repeat(0, N + 1).ToList(),
    lapsed = new List<int>(inorder), times = new List<int>(inorder);
var edgeList = inorder.Select(_ => new List<int>()).ToList();

for(int i = 1; i <= N; i++)
{
    input = read();
    times[i] = input[0];
    foreach (var next in input.Take(input.Count() - 1).Skip(1))
    {
        inorder[i]++;
        edgeList[next].Add(i);
    }
}

Queue<int> queue = new Queue<int>();
for(int i = 1; i <= N; i++) if(inorder[i] == 0) queue.Enqueue(i);

while(queue.Count > 0)
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