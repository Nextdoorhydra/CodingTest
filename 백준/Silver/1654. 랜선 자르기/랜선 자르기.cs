var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var g = new long[input[0]];
for (int i = 0; i < input[0]; i++) g[i] = int.Parse(Console.ReadLine());

long l = 1, r = g.Max(); ;
while (l <= r)
{
    long div = (l + r) / 2;
    long det = g.Sum(x => x / div);

    if(det >= input[1])
    {
        l = div + 1;
    }
    else if(det < input[1])
    {
        r = div - 1;
    }
}

Console.WriteLine(r);