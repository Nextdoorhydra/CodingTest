#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    int n;
    cin >> n;

    int l, r, count = 0;

    vector<int> vec(n);

    for (int i = 0; i < n; i++)
    {
        cin >> vec[i];
    }

    sort(vec.begin(), vec.end());

    for (int i = 0; i < n; i++)
    {
        int det = vec[i];
        l = i != 0 ? 0 : 1, r = i != n - 1 ? n - 1 : n - 2;
        while (l < r)
        {
            int sum = vec[l] + vec[r];

            if (sum > det)
            {
                r = r - 1 == i ? r - 2 : r - 1;
            }
            else if (sum < det)
            {
                l = l + 1 == i ? l + 2 : l + 1;
            }
            else
            {
                count++;
                break;
            }
        }
    }

    cout << count;

    return 0;
}