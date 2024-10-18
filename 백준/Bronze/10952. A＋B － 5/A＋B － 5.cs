string input;

while ((input = Console.ReadLine()) != null)
{
    var ls = input.Split().Select(int.Parse);
    int a = ls.First(), b = ls.Last();

    if (a == 0 && b == 0) break;
    Console.WriteLine(a + b);
}