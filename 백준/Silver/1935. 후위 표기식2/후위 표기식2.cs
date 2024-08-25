var num = new int[int.Parse(Console.ReadLine())];
var str = Console.ReadLine();
var stack = new Stack<double>();

for (int i = 0; i < num.Length; i++) num[i] = int.Parse(Console.ReadLine());

var oper = (double k2, double k1, char ch) => ch switch { '+' => k1 + k2, '-' => k1 - k2, '*' => k1 * k2, '/' => k1 / k2 };

foreach (var c in str)
{
    switch (c)
    {
        case '+' or '-' or '*' or '/':
            stack.Push(oper(stack.Pop(), stack.Pop(), c));
            break;
        default:
            stack.Push(num[c - 'A']);
            break;
    }
}

Console.WriteLine($"{stack.Pop():F2}");