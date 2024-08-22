#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    int n, target;
    cin >> n >> target;

    vector<int> vec(n);

    for (int i = 0; i < n; i++)
    {
        cin >> vec[i];
    }

    sort(vec.begin(), vec.end());

    int l = 0, r = n - 1, answer = 0;

    while (l < r)
    {
        int sum = vec[l] + vec[r];

        if (sum == target)
        {
            answer++;
            l++;
        }
        else if (sum < target)
        {
            l++;
        }
        else
        {
            r--;
        }
    }

    cout << answer;

    return 0;
}