#include <iostream>
#include <queue>
#include <vector>
#include <cmath>
using namespace std;

struct compare
{
    bool operator()(int k1, int k2)
    {
        int first_abs = abs(k1);
        int second_abs = abs(k2);
        if (first_abs == second_abs)
        {
            return k1 > k2;
        }
        else
        {
            return first_abs > second_abs;
        }
    }
};

main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    priority_queue<int, vector<int>, compare> heap;

    int n, temp;
    cin >> n;

    for (int i = 0; i < n; i++)
    {
        cin >> temp;
        if (temp == 0)
        {
            if (heap.empty())
            {
                cout << "0\n";
            }
            else
            {
                cout << heap.top() << "\n";
                heap.pop();
            }
        }
        else
        {
            heap.push(temp);
        }
    }

    return 0;
}