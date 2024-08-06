using static state;

//입력
var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var box = new int[input[0], input[1], input[2]];

for (int h = 0; h < box.GetLength(2); h++)
{
    for (int col = 0; col < box.GetLength(1); col++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int row = 0; row < box.GetLength(0); row++)
        {
            box[row, col, h] = input[row];
        }
    }
}

//declare
List<(int, int, int)> next = new List<(int, int, int)>();

var dx = new int[] { 1, 0, -1, 0, 0, 0 };
var dy = new int[] { 0, 1, 0, -1, 0, 0 };
var dz = new int[] { 0, 0, 0, 0, 1, -1 };

var cordinations = from x in Enumerable.Range(0, box.GetLength(0))
                    from y in Enumerable.Range(0, box.GetLength(1))
                    from z in Enumerable.Range(0, box.GetLength(2))
                    select (x, y, z);

Func<int[,,], (int x, int y, int z), bool> IsPassable = (arr, v) =>
    v.x >= 0 && v.x < arr.GetLength(0) &&
    v.y >= 0 && v.y < arr.GetLength(1) &&
    v.z >= 0 && v.z < arr.GetLength(2) &&
    (state)arr[v.x, v.y, v.z] == Raw;

//exe
int DAY = dfs(ref box);

foreach ((int x, int y, int z) l in cordinations) //검사
{
    if ((state)box[l.x, l.y, l.z] == Raw)
    {
        DAY = -1;
        break;
    }
}

Console.WriteLine(DAY);

//func
int dfs(ref int[,,] _box, int day = -1)
{
    for(var position = cordinations.Where(l => (state)box[l.x, l.y, l.z] == Rip).ToList(); 
        position.Count > 0; day++, next.Clear())
    {
        foreach ((int x, int y, int z) l in position)
        {
            for (int xyz = 0; xyz < 6; xyz++)
            {
                (int x, int y, int z) current = (l.x + dx[xyz], l.y + dy[xyz], l.z + dz[xyz]);
                if (IsPassable(_box, current))
                {
                    _box[current.x, current.y, current.z] = (int)Rip;
                    next.Add(current);
                }
            }
        }
        position = new List<(int, int, int)>(next);
    }
    return day;
}

enum state
{
    Empty = -1, Raw, Rip
}