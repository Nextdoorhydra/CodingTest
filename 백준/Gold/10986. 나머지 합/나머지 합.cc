#include <iostream>
#include <vector>

using namespace std;

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    int size, div;
    long answer = 0;
    cin >> size >> div;

    vector<long> sum(size, 0);
    vector<long> ans(div, 0);

    cin >> sum[0];
    ans[0]++;
    for (int i = 1, temp; i < size; i++)
    {
        cin >> temp;
        sum[i] = sum[i - 1] + temp;
    }

    for (int i = 0; i < size; i++)
    {
        ans[sum[i] % div]++;
    }

    for (auto i : ans)
    {
        answer += i * (i - 1) / 2;
    }

    cout << answer;

    return 0;
}