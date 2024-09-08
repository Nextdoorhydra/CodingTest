#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
#include <tuple>
using namespace std;
#define getNode get<0>
#define getWeight get<1>
using Edge = tuple<int, int>;

int rep;
vector<vector<Edge>> edgeList; //(node, weight)
Edge bfs(Edge);
void input();

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);
    input();

    Edge start = bfs(make_tuple(1, 0));
    Edge End = bfs(make_tuple(getNode(start), 0));
    cout << getWeight(End);
}

Edge bfs(Edge start)
{
    vector<bool> visited;
    visited.resize(rep + 1);

    queue<Edge> que;
    Edge result = start;
    que.push(start);

    while(!que.empty()){
        Edge e = que.front();
        que.pop();
        
        int node = getNode(e);
        visited[node] = true;

        for(auto& edge : edgeList[node]){
            if(!visited[getNode(edge)]){
                int sum = getWeight(edge) + getWeight(e);
                que.push(make_tuple(getNode(edge), sum));
                
                if(sum > getWeight(result)) result = make_tuple(getNode(edge), sum);
            }
        }
    }

    return result;
}

void input()
{
    cin >> rep;
    edgeList.resize(rep + 1);

    for (int i = 0; i < rep; i++)
    {
        int parent;
        tuple<int, int> node;
        cin >> parent;
        while (true)
        {
            cin >> getNode(node);
            if (getNode(node) == -1)
                break;
            cin >> getWeight(node);
            edgeList[parent].push_back(node);
        }
    }
}