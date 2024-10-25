using StreamWriter sw = new(Console.OpenStandardOutput());
Stack<int> st = new();
var read = () => Console.ReadLine().Split().ToList();
int N = int.Parse(read()[0]);
while(N-- > 0)
{
    var input = read();

    switch (input[0])
    {
        case "push":
            st.Push(int.Parse(input[1]));
            break;
        case "pop":
            sw.WriteLine(st.TryPop(out var x) ? x : -1);
            break;
        case "top":
            sw.WriteLine(st.TryPeek(out var t) ? t : -1);
            break;
        case "size":
            sw.WriteLine(st.Count());
            break;
        case "empty":
            sw.WriteLine(st.Count() == 0 ? 1 : 0);
            break;
    }
}