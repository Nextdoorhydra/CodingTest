using System;

Action<int, int> swap = (x, y) => { int temp = x; x = y; y = temp; };

string[] inputs = Console.ReadLine().Split(' ');
int x = int.Parse(inputs[0]); int y = int.Parse(inputs[1]);
Console.WriteLine($"{GCD(x, y)}\n{x * y / GCD(x, y)}");

int GCD(int x, int y)
{
    if (x < y) swap(x, y);
    if (y != 0) return GCD(y, x % y);
    return x;
}