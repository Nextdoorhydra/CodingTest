var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

Console.WriteLine(recur(input[0], input[1], input[2]));

decimal recur(int value, int depth, int mod)
{
    if (depth == 1) return value % mod;
    decimal ans = recur(value, depth / 2, mod) % mod;
    return ans * ans * (depth % 2 != 0 ? value % mod : 1) % mod;
}