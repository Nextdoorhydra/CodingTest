using StreamWriter sw = new(Console.OpenStandardOutput());
Queue<int> q = new();
var read = () => Console.ReadLine().Split().ToList();
int N = int.Parse(read()[0]);
while(N-- > 0)
{
    var input = read();

    switch (input[0])
    {
        case "push":
            q.Enqueue(int.Parse(input[1]));
            break;
        case "pop":
            sw.WriteLine(q.TryDequeue(out var x) ? x : -1);
            break;
        case "front":
            sw.WriteLine(q.Count() != 0 ? q.First() : -1);
            break;
        case "back":
            sw.WriteLine(q.Count() != 0 ? q.Last() : -1);
            break;
        case "size":
            sw.WriteLine(q.Count());
            break;
        case "empty":
            sw.WriteLine(q.Count() == 0 ? 1 : 0);
            break;
    }
}