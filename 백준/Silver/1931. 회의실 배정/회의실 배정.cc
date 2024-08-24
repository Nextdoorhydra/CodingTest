#include <iostream>
#include <algorithm>
#include <vector>
#include <tuple>
using namespace std;
typedef tuple<int, int> Node;

int main()
{
    ios::sync_with_stdio(false); cin.tie(NULL); cout.tie(NULL);

    int N, count = 0, end = -1;
    cin >> N;

    vector<Node> table(N);

    for(int i = 0; i < N; i++)
    {
        cin >> get<1>(table[i]);
        cin >> get<0>(table[i]);
    }

    std::sort(table.begin(), table.end());

    for(int i = 0; i < N; i++)
    {
        if(get<1>(table[i]) < end) continue;
        end = get<0>(table[i]);
        count++;
    }

    cout << count;

    return 0;
}