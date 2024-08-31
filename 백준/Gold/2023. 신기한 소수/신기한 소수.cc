#include <iostream>
using namespace std;

int n;
void dfs(int, int);
bool isPrime(int);

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    cin >> n;

    for (auto i : {2, 3, 5, 7})
        dfs(i, 1);

}

void dfs(int num, int depth)
{
    if (depth == n)
    {
        cout << num << '\n';
        return;
    }

    for (int i = 0; i <= 9; i++)
    {
        if (i % 2 == 0)
            continue;
        if (isPrime(num * 10 + i))
            dfs(num * 10 + i, depth + 1);
    }
}

bool isPrime(int num)
{
    for (int i = 2; i <= num / 2; i++)
    {
        if (num % i == 0)
            return false;
    }
    return true;
}