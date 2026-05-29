#include <string>
#include <vector>

using namespace std;

bool solution(string s)
{
    if (s.size() != 6 && s.size() != 4) return false;

    bool answer = true;

    for (auto& c : s)
    {
        if (c - '0' > 10 || c - '0' < 0)
        {
            answer = false;
            break;
        }
    }

    return answer;
}

int main()
{
    solution("1234567890aAbBcC");
}