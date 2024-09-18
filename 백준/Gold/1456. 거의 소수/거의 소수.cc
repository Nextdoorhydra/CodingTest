#include <iostream>
#include <vector>
#include <cmath>
#define MAX 10000001
using namespace std;
long prime[MAX];

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    long min, max, ANSWER = 0;
    cin >> min >> max;

    for (int i = 2; i < MAX; i++)
        prime[i] = i;

    for (int i = 2; i <= sqrt(MAX); i++)
    {
        if (prime[i] == 0)
            continue;
        for (int j = i + i; j < MAX; j += i)
            prime[j] = 0;
    }

    for (long n = 2; n * n <= max; n++)
    {
        if (prime[n] == 0)
            continue;

        long mul = n;
        while ((double)n <= (double)max / (double) mul)
        {
            if ((double)n >= min / (double)mul)
                ANSWER++;
            mul *= n;
        }
    }

    cout << ANSWER;
}