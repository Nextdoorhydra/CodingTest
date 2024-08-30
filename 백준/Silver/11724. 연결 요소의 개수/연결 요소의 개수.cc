#include <iostream>
#include <vector>
using namespace std;

static vector<vector<int>> list;
static vector<bool> visited;
void dfs(int v);

main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    int n, rep, ans = 0;

    cin >> n >> rep;

    list.resize(n + 1);
    visited = vector<bool>(n + 1, false);

    for (int i = 0; i < rep; i++)
    {
        int x, y;
        cin >> x >> y;
        list[x].push_back(y);
        list[y].push_back(x);
    }

    for (int i = 1; i < n + 1; i++)
    {
        if (!visited[i])
        {
            dfs(i);
            ans++;
        }
    }

    cout << ans;

    return 0;
}

void dfs(int v)
{
    if (visited[v])
        return;

    visited[v] = true;

    for (auto i : list[v])
    {
        if (!visited[i])
            dfs(i);
    }
}