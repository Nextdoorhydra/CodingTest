StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

int n = int.Parse(Console.ReadLine());

var sp = " ";
var ast = "*";

Action<int, string> print = (n, ch) => { for (int i = 0; i < n; i++) sw.Write(ch); };
Action cl = () => sw.WriteLine();

printf(0, n, 2 * n - 3, n);

for (int i = 1; i < n - 1; i++) printf(i, 1, n - 2, 1, 2 * (n - i) - 3, 1, n - 2, 1);

printf(n - 1, 1, n - 2, 1, n-2, 1);

for (int i = n - 2; i > 0; i--) printf(i, 1, n - 2, 1, 2 * (n - i) - 3, 1, n - 2, 1);

printf(0, n, 2 * n - 3, n);

sw.Close();

void printf(params int[] arg)
{
    for(int i = 0; i < arg.Length; i += 2)
    {
        print(arg[i], sp);
        print(arg[i + 1], ast);
    }
    cl();
};