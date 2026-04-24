#include <string>
#include <vector>
#include <queue>

using namespace std;

int solution(int bridge_length, int weight, vector<int> truck_weights) {
    // init
    struct Truck {
        int weight;
        int waitTime;
    };

    int answer = 1, currentWeight = 0, truck;
    vector<int> wait;
    queue<Truck> q;
    queue<Truck> wq;

    // process
    for (int w : truck_weights) {
        q.push(Truck{ w, bridge_length });
    }

    // main
    while (1) {

        if (!q.empty()) {
            Truck truck = q.front();

            if (weight >= currentWeight + truck.weight) {
                currentWeight += truck.weight;
                wq.push(truck);
                q.pop();
            }
        }

        if (!wq.empty()) {
            answer++;
            int loop = wq.size();

            for (int i = 0; i < loop; i++) {
                Truck _truck = wq.front();
                wq.pop();

                _truck.waitTime--;

                if (_truck.waitTime > 0) {
                    wq.push(_truck);
                }
                else {
                    currentWeight -= _truck.weight;
                }
            }
        }

        if (wq.empty() && q.empty()) break;
    }

    return answer;
}