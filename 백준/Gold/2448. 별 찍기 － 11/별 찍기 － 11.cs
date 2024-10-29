using StreamWriter sw = new(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine()), pos = 0;
var map = new int[n, 2 * n - 1];

recur(0, n - 1, n);
print();

void recur(int r, int c, int height)
{
    if(height == 3)
    {
        map[r, c] = 1;
        map[r + 1, c - 1] = 1;
        map[r + 1, c + 1] = 1;
        map[r + 2, c] = 1;
        map[r + 2, c - 1] = 1;
        map[r + 2, c - 2] = 1;
        map[r + 2, c + 1] = 1;
        map[r + 2, c + 2] = 1;
        return;
    }
    
    int half = height / 2;

    recur(r, c, half);
    recur(r + half, c - half, half);
    recur(r + half, c + half, half);
}

void print() { for(int r = 0; r < n; r++) { for(int c = 0; c < 2 * n - 1; c++) sw.Write(map[r, c] == 1 ? '*' : ' '); sw.WriteLine(); } }