var condi = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int k = (int)Math.Pow(2, condi[0]), answer = 0;

recur(k / 4, k / 2, k / 2);

void recur(int n, int row, int col)
{
    var IsEnd = (int r, int c) =>
    {
        if (r == condi[1] && c == condi[2]) Console.WriteLine(answer);
        answer++;
    };

    if (n == 0)
    {
        IsEnd(row - 1, col - 1);
        IsEnd(row - 1, col);
        IsEnd(row, col - 1);
        IsEnd(row, col);
    }
    else
    {
        int cnt = n * n * 4;

        switch (row <= condi[1], col <= condi[2])
        {
            case (false, false):
                recur(n / 2, row - n, col - n);
                break;
            case (false, true):
                answer += cnt;
                recur(n / 2, row - n, col + n);
                break;
            case (true, false):
                answer += 2 * cnt;
                recur(n / 2, row + n, col - n);
                break;
            case (true, true):
                answer += 3 * cnt;
                recur(n / 2, row + n, col + n);
                break;
        }
    }
}