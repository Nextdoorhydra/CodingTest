const int MAX = 100001;
var queue = new Queue<int>();
var visited = new bool[MAX];
var move = new Func<int, int>[2];
move[0] = (int x) => x - 1; move[1] = (int x) => x + 1;

var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int start = input[0], end = input[1], count = 0, answer = int.MaxValue;
var map = new int[MAX];
map[start]++; map[end]++;

var IsPassable = (int x) => x >= 0 && x < MAX;
var getTelePos = (int x) =>
{
    if (x is 0) return Enumerable.Repeat(0, 1);
    var seq = Enumerable.Range(0, MAX).Select(n => x * (int)Math.Pow(2, n)).TakeWhile(IsPassable);
    return seq.Where(x => x <= end).Concat(seq.Where(x => x > end).Take(1));
};

queue.Enqueue(start);
queue.Enqueue(-1);

while (queue.Count > 1)
{
    while(queue.Peek() != -1)
    {
        foreach (var pos in getTelePos(queue.Dequeue()))
        {
            if (visited[pos]) continue;
            visited[pos] = true;
            queue.Enqueue(pos);
        }
    }
    queue.Dequeue();
    queue.Enqueue(-1);

    while (queue.Peek() != -1)
    {
        int current = queue.Dequeue();

        if (current == end)
        {
            answer = Math.Min(answer, count);
            goto OUT;
        }
        else if (current > end)
        {
            answer = Math.Min(answer, count + current - end);
        }
        else
        {
            foreach (var f in move)
            {
                int pos = f(current);
                if (!IsPassable(pos) || visited[pos]) continue;
                queue.Enqueue(pos);
            }
        }
    }

    queue.Dequeue();
    queue.Enqueue(-1);
    count++;
}

OUT:  Console.WriteLine(answer);