while (true)
{
    var s = Console.ReadLine();
    if (s == "0") return;

    int l = 0, r = s.Length - 1;
    while (l < r) if (s[l++] != s[r--]) r = -1;

    Console.WriteLine(r != -1 ? "yes" : "no");
}