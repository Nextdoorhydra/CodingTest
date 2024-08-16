var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int inventory = input[2];
var g = new int[input[0] * input[1]];

for (int i = 0; i < g.Length;)
{
    var _input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    foreach (int x in _input) g[i++] = x;
}

//메인
var ans = new int[2];
var Working = (int[] arr, int level, int n) =>
{
    for (int i = 0; i < arr.Length; i++) if (arr[i] == level) arr[i] += n;
};

while (true)
{
    int top = 0, btm = int.MaxValue;
    var level = new int[257];

    for(int i = 0; i < g.Length; i++)
    {
        top = ans[1] = Math.Max(g[i], top);
        btm = Math.Min(g[i], btm);
        level[g[i]]++;
    }

    if (top == btm) break;

    int topCnt = level[top], btmCnt = level[btm];

    if (inventory < btmCnt || 2 * topCnt < btmCnt)
    {
        //dig
        inventory += topCnt;
        ans[0] += 2 * topCnt;
        Working(g, top, -1);
    }
    else
    {
        //fill
        inventory -= btmCnt;
        ans[0] += btmCnt;
        Working(g, btm, 1);
    }
}

Console.WriteLine($"{ans[0]} {ans[1]}");