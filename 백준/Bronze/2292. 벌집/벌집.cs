int n = int.Parse(Console.ReadLine());

if (n-- == 1)
{
    Console.WriteLine(1);
    return;
}

int i = 0;
for(; n > 0; i++)
{
    n -= 6 * i;
}

Console.WriteLine(i);