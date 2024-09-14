var rep = int.Parse(Console.ReadLine());
var map = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] MAX = new int[3], MIN = new int[3];
Array.Copy(map, MAX, 3);
Array.Copy(map, MIN, 3);

for (int r = 1; r < rep; r++)
{
    map = Console.ReadLine().Split().Select(int.Parse).ToArray();

    int[] _MAX = new int[3], _MIN = new int[3];
    Array.Copy(MAX, _MAX, 3);
    Array.Copy(MIN, _MIN, 3);

    for (int c = 0; c < 3;  c++)
    {
        MAX[c] = map[c] + Math.Max(Math.Max(_MAX[c - 1 < 0 ? c : c - 1], _MAX[c]),
            _MAX[c + 1 >= 3 ? c : c + 1]);
        MIN[c] = map[c] + Math.Min(Math.Min(_MIN[c - 1 < 0 ? c : c - 1], _MIN[c]),
            _MIN[c + 1 >= 3 ? c : c + 1]);
    }
}

Console.WriteLine($"{MAX.Max()} {MIN.Min()}");