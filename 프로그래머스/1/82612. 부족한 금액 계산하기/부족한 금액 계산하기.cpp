using namespace std;

long long solution(int price, int money, int count)
{
    long long acc = 0;

    for (int i = 1; i <= count; i++)
    {
        acc += price * i;
    }

    long long m = money - acc;

    return m > 0 ? 0 : -m;
}