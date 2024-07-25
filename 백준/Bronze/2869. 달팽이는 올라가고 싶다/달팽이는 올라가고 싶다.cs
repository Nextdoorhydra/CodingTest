string[] arr = Console.ReadLine().Split(' ');

Args arg = new Args() { A = int.Parse(arr[0]), B = int.Parse(arr[1]), V = int.Parse(arr[2]) };

int WhenArrive(Args arg)
{
    int v = arg.V - arg.A;
    int gap = arg.A - arg.B;
    if (v % gap == 0) return v / gap;
    return v / gap + 1;
}

Console.WriteLine(WhenArrive(arg) + 1);

struct Args
{
    public int A; public int B; public int V;
}