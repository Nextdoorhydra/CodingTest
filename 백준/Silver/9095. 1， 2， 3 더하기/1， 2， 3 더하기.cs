var memo = new int[100]; memo[0] = 1;

int N = int.Parse(Console.ReadLine());

while(N-- > 0) Console.WriteLine(recur(int.Parse(Console.ReadLine())));

int recur(int a, int b = 0, int c = 0)
{
    if (a < 0) return 0;
    int sum = 0;

    sum += (b == 0 ? recur(a - 3, c: c + 1) : 0) + recur(a - 2, b + 1, c);
    return sum += Fac(a + b + c) / Fac(a) / Fac(b) / Fac(c);
}

int Fac(int n)
{
    if (n <= 1) return 1;
    if (memo[n - 1] != 0) return memo[n - 2] * n;
    return memo[n - 1] = Fac(n - 1) * n;
}