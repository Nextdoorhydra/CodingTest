#include <iostream>
#include <vector>
#include <queue>
using namespace std;

queue<int> que;
vector<vector<int>> edgeList;
vector<bool> visited;
void dfs(int);
void bfs(int);

int main()
{
    ios::sync_with_stdio(false); cin.tie(NULL); cout.tie(NULL);

    int n, m, src;
    cin >> n >> m >> src;

    edgeList.resize(n + 1);

    for(int i = 0; i < m; i++){
        int s, e;
        cin >> s >> e;
        edgeList[s].push_back(e);
        edgeList[e].push_back(s);
    }

    for(auto& edge : edgeList){
        sort(edge.begin(), edge.end());
    }

    visited = vector<bool>(n + 1, false);
    dfs(src);
    cout << '\n';
    visited = vector<bool>(n + 1, false);
    bfs(src);
    cout << '\n';
}

void dfs(int node){
    cout << node << ' ';
    visited[node] = true;
    for(auto v : edgeList[node]){
        if(!visited[v]){
            dfs(v);
        }
    }
}

void bfs(int node){
    que.push(node);
    visited[node] = true;

    while(!que.empty()){
        int _node = que.front();
        cout << _node << ' ';
        que.pop();

        for(auto v : edgeList[_node]){
            if(!visited[v]){
                visited[v] = true;
                que.push(v);
            }
        }
    }
}