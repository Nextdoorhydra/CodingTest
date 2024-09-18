#include <iostream>
#include <vector>
#include <numeric>
#include <cmath>
#define MAX 2'000'000
using namespace std;

vector<int> prime(MAX + 1);
bool isPalindrome(int);
void getPrime(vector<int> &);

int main()
{
    getPrime(prime);

    int target;
    cin >> target;

    for (int n : prime)
    {
        if (n >= target && isPalindrome(n))
        {
            cout << n;
            return 0;
        }
    }
}

bool isPalindrome(int n)
{
    if (n < 10)
        return true;

    string str = to_string(n);
    int l = 0, r = str.size() - 1;

    while (l < r)
    {
        if (str[l] != str[r])
            return false;

        l++, r--;
    }
    return true;
}

void getPrime(vector<int> &A)
{
    iota(A.begin(), A.end(), 0);
    A[1] = 0;

    for (int i = 2; i <= sqrt(MAX); i++)
    {
        if (A[i] == 0)
            continue;
        for (int j = i + i; j <= MAX; j += i)
            A[j] = 0;
    }
}