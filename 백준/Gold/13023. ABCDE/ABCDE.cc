#include <iostream>
#include <ranges>
#include <vector>
using namespace std;

bool arrive;
vector<vector<int>> A;
vector<bool> visited;
void dfs(int, int);

int main()
{
    int n, m;
    cin >> n >> m;

    A.resize(n);
    visited = vector<bool>(n, false);

    for (int i = 0; i < m; i++)
    {
        int v1, v2;
        cin >> v1 >> v2;

        A[v1].push_back(v2);
        A[v2].push_back(v1);
    }

    for (auto i : views::iota(0, n))
    {
        if (!arrive)
            dfs(i, 1);
    }

    cout << (arrive ? 1 : 0);
}

void dfs(int v, int depth)
{
    if (depth == 5 || arrive)
    {
        arrive = true;
        return;
    }
    
    visited[v] = true;

    for (int i : A[v])
    {
        if (!visited[i])
            dfs(i, depth + 1);
    }

    visited[v] = false;
}