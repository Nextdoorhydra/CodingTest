StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

int n = 4 * int.Parse(Console.ReadLine()) - 3;

var sp = " ";
var ast = "*";
var asp = "* ";
var spa = " *";

Action<int, string> print = (n, ch) => { for (int i = 0; i < n; i++) sw.Write(ch); };
Action cl = () => sw.WriteLine();
Action<int, int, int, string> printL = (l, m, r, ch) =>
{
    print(l, asp);
    print(m, ch);
    print(r, spa); cl();
};

printL(0, n, 0, ast);

if(n > 1)
{
    top(n, 2, 0);

    printL(0, 1, (n - 1) / 2, ast);
    btm(n);
}

sw.Close();

void top(int n, int l, int r)
{
    int m = n - l - r;

    if (m < 3) return;
    
    printL(l / 2, l == 2 ? 0 : m, r / 2, sp);
    printL(l / 2, m, r / 2, ast);

    top(n, l += 2, r += 2);
}

void btm(int n, int acc = 0)
{
    int _n = 4 * acc + 1;
    int _lr = (n - _n) / 4;

    printL(_lr, _n, _lr, ast);
    if (n == _n) return;
    printL(_lr, _n, _lr, sp);

    btm(n, ++acc);
}