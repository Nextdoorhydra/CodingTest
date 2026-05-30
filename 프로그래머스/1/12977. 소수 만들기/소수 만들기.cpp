#include <vector>
#include <cmath>
#include <iostream>
using namespace std;

int solution(vector<int> nums)
{
    int answer = 0;
    vector<bool> isPrime(3001, false);
    vector<int> prime;

    isPrime[2] = true;
    prime.push_back(2);

    for (int i = 3; i < isPrime.size(); i += 2)
    {
        bool flag = true;

        for (int p : prime)
        {
            if (p * p > i) break;

            if (i % p == 0)
            {
                flag = false;
                break;
            }
        }

        if (flag)
        {
            isPrime[i] = true;
            prime.push_back(i);
        }
    }

    for (int i = 0; i < nums.size(); i++)
    {
        for (int j = i + 1; j < nums.size(); j++)
        {
            for (int k = j + 1; k < nums.size(); k++)
            {
                int num = nums[i] + nums[j] + nums[k];

                if (isPrime[num])
                    answer++;
            }
        }
    }

    return answer;
}