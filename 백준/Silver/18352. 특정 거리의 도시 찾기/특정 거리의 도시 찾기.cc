#include <iostream>
#include <vector>
#include <queue>
#include <tuple>
#define INTMax 2147483647;
using namespace std;
using Node = tuple<int, int>;
priority_queue<Node, vector<Node>, greater<Node>> pq;
vector<int> distances;
vector<vector<Node>> EdgeList;

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    int N, M, K, X;
    cin >> N >> M >> K >> X;

    EdgeList.resize(N + 1);
    distances.resize(N + 1);

    for (auto &i : distances)
    {
        i = INTMax;
    }

    for (int i = 0; i < M; i++)
    {
        int k1, k2;
        cin >> k1 >> k2;
        EdgeList[k1].push_back(make_tuple(1, k2));
    }

    distances[X] = 0;
    pq.push(make_tuple(0, X));

    while (!pq.empty())
    {
        int current = get<1>(pq.top());
        pq.pop();

        for (auto next : EdgeList[current])
        {
            int distance = distances[current] + get<0>(next);
            if(distance > K) continue;

            if (distances[get<1>(next)] > distance)
            {
                distances[get<1>(next)] = distance;
                pq.push(make_tuple(distance, get<1>(next)));
            }
        }
    }

    vector<int> answer;

    for (int i = 1; i <= N; i++)
    {
        if (distances[i] == K)
            answer.push_back(i);
    }

    if (answer.empty())
    {
        cout << -1;
    }
    else
    {
        for (int i : answer)
            cout << i << '\n';
    }
}