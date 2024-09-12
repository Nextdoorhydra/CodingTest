int N = int.Parse(Console.ReadLine()), ANSWER = 0;
var column = new bool[N];
var LDiagonal = new bool[N * 2 + 1]; //r-c + N
var RDiagonal = new bool[N * 2 + 1];

var updateQueen = ((int r, int c) pos, bool status) =>
{
    column[pos.c] = status;
    LDiagonal[pos.r - pos.c + N] = status;
    RDiagonal[pos.r + pos.c] = status;
};

var validCheck = ((int r, int c) pos) =>
{
    var IsPassable = ((int r, int c) x) => x.r >= 0 && x.c >= 0 && x.r < N && x.c < N;
    var IsAttack = ((int r, int c) x) => column[x.c] || LDiagonal[x.r - x.c + N] || RDiagonal[x.r + x.c];

    return IsPassable(pos) && !IsAttack(pos);
};

NQueen();
Console.WriteLine(ANSWER);

void NQueen(int r = 0)
{
    if(r == N)
    {
        ANSWER++;
        return;
    }

    foreach(var c in Enumerable.Range(0, N))
    {
        var pos = (r, c);

        if (validCheck(pos))
        {
            updateQueen(pos, true);
            NQueen(r + 1);
            updateQueen(pos, false);
        }
    }
}