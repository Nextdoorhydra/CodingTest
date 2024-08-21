#include <iostream>
#define size 1024

using namespace std;

int g[size + 1][size + 1];

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    int rc, rep, input;
    cin >> rc >> rep;

    for (int r = 1; r <= rc; r++)
    {
        for (int c = 1; c <= rc; c++)
        {
            cin >> input;
            g[r][c] = input + g[r - 1][c] + g[r][c - 1] - g[r - 1][c - 1];
        }
    }

    for (int i = 0; i < rep; i++)
    {
        int x1, y1, x2, y2;
        cin >> x1 >> y1 >> x2 >> y2;
        cout << g[x2][y2] - g[x2][y1 - 1] - g[x1 - 1][y2] + g[x1 - 1][y1 - 1]<< "\n";
    }

    return 0;
}