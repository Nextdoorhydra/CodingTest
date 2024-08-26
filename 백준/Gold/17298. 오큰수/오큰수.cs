Console.ReadLine();
var seq = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var stack = new Stack<int>();

for (int i = 0; i < seq.Length; i++)
{
    while (stack.Count > 0)
    {
        if (seq[i] <= seq[stack.Peek()]) break;
        seq[stack.Peek()] = -seq[i];
        stack.Pop();
    }
    stack.Push(i);
}

Console.WriteLine(string.Join(" ", seq.Select(x => x switch { < 0 => -x, >0 => -1 })));