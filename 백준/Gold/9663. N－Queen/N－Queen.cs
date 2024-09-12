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

NQueen();
Console.WriteLine(ANSWER);

void NQueen(int r = 0)
{
    if (r == N)
    {
        ANSWER++;
        return;
    }

    foreach (var c in Enumerable.Range(0, N))
    {
        var pos = (r, c);

        if (!column[pos.c] && !LDiagonal[pos.r - pos.c + N] && !RDiagonal[pos.r + pos.c])
        {
            updateQueen(pos, true);
            NQueen(r + 1);
            updateQueen(pos, false);
        }
    }
}