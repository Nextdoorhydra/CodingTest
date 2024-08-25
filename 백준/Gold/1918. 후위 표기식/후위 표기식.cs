Console.WriteLine(ToPostfixNotation(Console.ReadLine()));

string ToPostfixNotation(string str)
{
    int pr = 0;
    var ans = new List<char>();
    var stack = new Stack<(char ch, int pr)>();

    var Pop = (List<char> ls, int pr) =>
    {
        while (stack.Count > 0 && stack.Peek().pr >= pr) ls.Add(stack.Pop().ch);
    };

    var Priority = (char ch) => ch switch
    {
        '+' or '-' => 1,
        '*' or '/' => 2,
        _ => 0
    };

    var Process = (char ch, int acc) =>
    {
        int prior = Priority(ch) + acc;
        if (stack.Count == 0 || stack.Peek().pr < prior)
        {
            stack.Push((ch, prior));
        }
        else
        {
            Pop(ans, prior);
            stack.Push((ch, prior));
        }
    };

    foreach (var c in str)
    {
        switch (c)
        {
            case '+' or '-' or '*' or '/':
                Process(c, pr);
                break;
            case '(':
                pr += 2;
                break;
            case ')':
                pr -= 2;
                break;
            default:
                ans.Add(c);
                break;
        }
    }
    Pop(ans, -1);

    return string.Join("", ans);
}