var condi = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int k = (int)Math.Pow(2, condi[0] - 1), answer = 0;

recur(k / 2, k, k);
Console.WriteLine(answer);

void recur(int n, int row, int col)
{
    int cnt = n * n * 4;

    switch (row <= condi[1], col <= condi[2])
    {
        case (false, false):
            if(n != 0) recur(n / 2, row - n, col - n);
            break;
        case (false, true):
            answer += n == 0 ? 1 : cnt; 
            if (n != 0) recur(n / 2, row - n, col + n);
            break;
        case (true, false):
            answer += n == 0 ? 2 : 2 * cnt;
            if (n != 0) recur(n / 2, row + n, col - n);
            break;
        case (true, true):
            answer += n == 0 ? 3 : 3 * cnt;
            if (n != 0) recur(n / 2, row + n, col + n);
            break;
    }
}