#include <iostream>
#include <vector>
#include <algorithm>
#define size 100000

using namespace std;

void dfs(int);
vector<vector<int>> tree;
int ans[size];
bool visited[size];

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    tree.resize(size);

    int rep;
    cin >> rep;

    for (int i = 1; i < rep; i++)
    {
        int l, r;
        cin >> l >> r;
        tree[--l].push_back(--r);
        tree[r].push_back(l);
    }

    dfs(0);

    for (int i = 1; i < rep; i++)
    {
        cout << ++ans[i] << "\n";
    }

    return 0;
}

void dfs(int k)
{
    visited[k] = true;

    for (int i : tree[k])
    {
        if (!visited[i])
        {
            ans[i] = k;
            dfs(i);
        }
    }
}