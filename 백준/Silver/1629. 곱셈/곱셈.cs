var i = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Console.WriteLine(recur(i[0], i[1], i[2]));

decimal recur(int n, int pow, int mod)
{
    if (pow == 1) return n % mod;
    decimal ans = recur(n, pow / 2, mod) % mod;
    return ans * ans * (pow % 2 != 0 ? n % mod : 1) % mod;
}