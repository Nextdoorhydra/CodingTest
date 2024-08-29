#include <iostream>
#include <queue>
#include <vector>
#include <cmath>
using namespace std;

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    priority_queue<pair<int, int>, vector<pair<int, int>>, greater<pair<int, int>>> heap;
    priority_queue<int, vector<int>, greater<int>> compare;
    vector<int> ans;
    auto push = [&heap](int x)
    { heap.push(make_pair(abs(x), x)); };

    int n, temp;
    cin >> n;

    for (int i = 0; i < n; i++)
    {
        cin >> temp;

        if (temp != 0)
        {
            push(temp);
        }
        else
        {
            if (heap.size() == 0)
            {
                ans.push_back(0);
            }
            else
            {
                temp = heap.top().second;
                while (heap.size() > 0 && heap.top().first == abs(temp))
                {
                    compare.push(heap.top().second);
                    heap.pop();
                }

                ans.push_back(compare.top());
                compare.pop();

                while (compare.size() > 0)
                {
                    push(compare.top());
                    compare.pop();
                }
            }
        }
    }

    for (auto i : ans)
        cout << i << "\n";
    return 0;
}