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

if(n == 1)
{
    print(1, ast);
}
else
{
    print(n, ast); cl();
    print(1, ast); cl();

    recur(n);

    print(1, ast);
    print((n - 1) / 2, spa); cl();

    recur2(n);
}

sw.Close();

void recur(int n, int l = 2, int r = 0)
{
    if (n - l - r < 3) return;
    printL(l / 2, n - l - r, r / 2, ast);

    if (n - l - r - 4 < 3) return;
    printL((l + 2) / 2, n - l - r - 4, (r + 2) / 2, sp);

    recur(n, l += 2, r += 2);
}
void recur2(int n, int acc = 0)
{
    int _n = 4 * acc + 1;
    int _lr = (n - _n) / 4;

    printL(_lr, _n, _lr, ast);
    printL(_lr, _n, _lr, sp);

    if (n == _n) return;
    recur2(n, ++acc);
}