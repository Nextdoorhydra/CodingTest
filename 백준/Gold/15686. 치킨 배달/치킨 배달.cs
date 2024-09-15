var input = Console.ReadLine().Split().Select(int.Parse).ToList();
int N = input[0], M = input[1], ANSWER = int.MaxValue;
List<(int r, int c)> chicken = new(), house = new();

//input data
for (int r = 0; r < N; r++)
{
    input = Console.ReadLine().Split().Select(int.Parse).ToList();

    for (int c = 0; c < N; c++)
    {
        switch (input[c])
        {
            case 1:
                house.Add((r, c));
                break;
            case 2:
                chicken.Add((r, c));
                break;
        }
    }
}

var distance = ((int x1, int y1) c1, (int x2, int y2) c2) => Math.Abs(c1.x1 - c2.x2) + Math.Abs(c1.y1 - c2.y2);
var chickenDistance = chicken.Select(x => house.Select(y => distance(x, y)).ToList()).ToList();

f(new List<int>());

void f(IEnumerable<int> ls, int idx = 0, int depth = 0)
{
    if(depth == M)
    {
        var select = ls.Select(i => chickenDistance[i]).ToList();
        int total = Enumerable.Range(0, house.Count).Select(i => select.Select(ls => ls[i]).Min()).Sum();
        ANSWER = Math.Min(total, ANSWER);
        return;
    }

    for(int i = idx; i < chickenDistance.Count; i++)
    {
        if (!ls.Contains(i))
        {
            f(ls.Append(i), i + 1, depth + 1);
        }
    }
}

Console.WriteLine(ANSWER);