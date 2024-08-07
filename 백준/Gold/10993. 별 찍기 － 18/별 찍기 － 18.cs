StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

//너비 구하기
var memo = new int[10];
memo[0] = 1; memo[1] = 5;
int n = 1, input = int.Parse(Console.ReadLine());
for(int i = 1; i < input; i++) memo[i] = n = (memo[i - 1] + 2) * 2 - 1;

var g = new int[n / 2 + 1, n];

//hg 구하기
int[] hg = new int[100];

if (input % 2 != 0)
{
    hg[0] = 0; hg[1] = n / 2 + - 1;
}
else
{
    hg[0] = n / 2; hg[1] = 1;
}

var offset = Enumerable.Range(input % 2 != 0 ? 1 : 2, 100).Select(x => x % 2 == 0 ? -1 : 2).ToArray();

for (int i = 2; i < offset.Length; i++)
{
    hg[i] = (hg[i - 1] + hg[i - 2]) / 2 + offset[i];
}

//재귀
var dx = new int[,] { { -1, 1, -1 }, { 1, -1, 1 } };
var dy = new int[,] { { 1, 0, -1 }, { -1, 0, 1 } };

//판별식
Func<int, int, bool> IsPassable = (y, x) => x >= 0 && x < g.GetLength(1) && y >= 0 && y < g.GetLength(0);
Func<int, int, int, int, bool> IsAnyone = (y, x, dy, dx) => (dy == 0 || g[y + dy, x] == 0) && (dx == 0 || g[y, x + dx] == 0);
Func<int, int, bool> IsEnd = (y, x) => 
    IsPassable(y, x + 1) && g[y, x + 1] == 1 &&
    IsPassable(y, x - 1) && g[y, x - 1] == 1;

void recur(int acc, int sw)
{
    (int y, int x) l = (hg[acc], n / 2);
    g[l.y, l.x] = 1;

    //사방이 막히면 종료
    if (IsEnd(l.y, l.x)) return;

    for (int xy = 0; xy < 3; xy++)
    {
        while (IsPassable(l.y + dy[sw % 2, xy], l.x + dx[sw % 2, xy]))
        {
            l = (l.y + dy[sw % 2, xy], l.x + dx[sw % 2, xy]);
            g[l.y, l.x] = 1;
            if(!IsPassable(l.y + dy[sw % 2, xy], l.x + dx[sw % 2, xy]) || !IsAnyone(l.y, l.x, dy[sw % 2, xy], dx[sw % 2, xy])) break;
        }
    }
    recur(++acc, ++sw);
}

if(input < 2)
{
    //1처리
    g[0, 0] = 1;
}
else 
{
    recur(0, ++input % 2);
}

//오른 공백 지우기 - 문제 조건 맞춤
for (int i = 0; i < g.GetLength(0); i++)
{
    for (int j = g.GetLength(1) - 1; j >= 0; j--)
    {
        if (g[i, j] == 1) break;
        g[i, j] = -1;
    }
}

display(g);
sw.Close();

void display(int[,] arr)
{
    for(int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            sw.Write(arr[i, j] == 0 ? " " : arr[i, j] == 1 ? "*" : "");
        }
        sw.WriteLine();
    }
};