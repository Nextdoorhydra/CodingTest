#include <iostream>
#include <vector>
#include <numeric>
#define MAX 1'000'001
using namespace std;

vector<int> prime(MAX);
void getPrime(vector<int> &);

int main()
{
    long long n, _n, rest;
    cin >> n;

    _n = n, rest = n;

    iota(prime.begin(), prime.end(), 0);

    for (int i = 2; i < MAX; i++)
    {
        if (prime[i] == 0)
            continue;

        if (n % i == 0)
        {
            _n -= _n / i;
            while (rest % i == 0)
                rest /= i;
        }

        for (int j = i + i; j < MAX; j += i)
            prime[j] = 0;
    }

    if (rest != 1)
        _n -= _n / rest;

    cout << _n;
}