int ans = 0;
var n = int.Parse(Console.ReadLine());

while(ans++ < n)
{
    if (ans + ans.ToString().Sum(x => x - '0') == n)
    {
        Console.WriteLine(ans);
        return;
    }
}

Console.WriteLine(0);