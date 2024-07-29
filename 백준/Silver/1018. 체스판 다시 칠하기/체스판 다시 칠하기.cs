var cordi = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[,] board = new int[cordi[0], cordi[1]]; 
int[,] board2 = new int[cordi[0], cordi[1]];
int[,] board3 = new int[cordi[0], cordi[1]]; 

for (int i = 0; i < cordi[0]; i++)
{
    string s = Console.ReadLine();
    for(int j = 0; j < s.Length; j++)
    {
        if (s[j] == 'B') board[i, j] = board2[i, j] = board3[i, j] = 1;
        else board[i, j] = board2[i, j] = board3[i, j] = 0;
    }
}

int[] pat2 = Enumerable.Range(0, cordi[1]).Select(i => i % 2).ToArray();
int[] pat3 = Enumerable.Range(1, cordi[1]).Select(i => i % 2).ToArray();

for(int i = 0; i < cordi[0]; i++)
{
    if (i % 2 == 0)
    {
        for (int j = 0; j < cordi[1]; j++)
        {
            if ((board[i, j] != pat2[j]))
            {
                board2[i, j] = 2;
            }
        }
        for (int j = 0; j < cordi[1]; j++)
        {
            if ((board[i, j] != pat3[j]))
            {
                board3[i, j] = 3;
            }
        }
    }
    else
    {
        for (int j = 0; j < cordi[1]; j++)
        {
            if ((board[i, j] != pat3[j]))
            {
                board2[i, j] = 2;
            }
        }
        for (int j = 0; j < cordi[1]; j++)
        {
            if ((board[i, j] != pat2[j]))
            {
                board3[i, j] = 3;
            }
        }
    }
}

int ANS = int.MaxValue;

for(int i = 0; i <= cordi[0] - 8; i++)
{
    for (int j = 0; j <= cordi[1] - 8; j++)
    {
        int cnt1 = 0; int cnt2 = 0;
        for(int r = i; r < i + 8; r++)
        {
            for(int c = j; c < j + 8; c++)
            {
                if (board2[r, c] == 2) cnt1++;
                if (board3[r, c] == 3) cnt2++;
            }
        }
        ANS = Math.Min(Math.Min(cnt1, cnt2), ANS);
    }
}

Console.WriteLine(ANS == int.MaxValue ? 0 : ANS);