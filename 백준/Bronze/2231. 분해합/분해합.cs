int ans = 0;
var n = int.Parse(Console.ReadLine());

while(ans++ < n)
{
    if (ans + ans.ToString().Select(x => x - '0').Sum() == n)
    {
        Console.WriteLine(ans);
        return;
    }
}

Console.WriteLine(0);