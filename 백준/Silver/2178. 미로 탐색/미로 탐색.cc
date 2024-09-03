#include <iostream>
#include <vector>
#include <queue>
#include <tuple>
using namespace std;
using Node = tuple<int, int>;
queue<Node> que;
vector<vector<int>> map;
vector<vector<bool>> visited;
void bfs(Node node, int n, int m);

int main()
{
    ios::sync_with_stdio(false); cin.tie(NULL); cout.tie(NULL);

    int n, m;
    cin >> n >> m;

    map.resize(n, vector<int>(m));
    visited.resize(n, vector<bool>(m, false));

    for(int i = 0; i < n; i++){
        string line;
        cin >> line;
        transform(line.begin(), line.end(), map[i].begin(), [](char c) { return c - '0'; });
    }

    bfs(make_tuple(0, 0), n, m);
}

void bfs(Node node, int n, int m){
    int dx[] = { 0, 1, 0, -1 };
    int dy[] = { 1, 0, -1, 0 };
    auto IsPassable = [n, m](Node x) 
    { return get<0>(x) >= 0 && get<0>(x) < n && get<1>(x) >= 0 && get<1>(x) < m; };

    que.push(node);
    visited[get<0>(node)][get<1>(node)] = true;

    while(!que.empty()){
        Node current = que.front();
        que.pop();

        for(int i = 0; i < 4; i++){
            Node next = make_tuple(get<0>(current) + dx[i], get<1>(current) + dy[i]);

            if(IsPassable(next) 
            && !visited[get<0>(next)][get<1>(next)]
            && map[get<0>(next)][get<1>(next)] != 0){
                visited[get<0>(next)][get<1>(next)] = true;
                que.push(next);
                map[get<0>(next)][get<1>(next)] = map[get<0>(current)][get<1>(current)] + 1;
            }
        }
    }

    cout << map[n - 1][m - 1];
}