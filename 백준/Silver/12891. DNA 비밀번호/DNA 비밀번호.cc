#include <iostream>

using namespace std;

int condi[4];
int cnt[4];

int main()
{
    string str;
    int l, r, length, size, count = 0;

    auto GetCount = [](int *cnt, char det, int n)
    {
        switch (det)
        {
        case 'A':
            cnt[0] += n;
            break;
        case 'C':
            cnt[1] += n;
            break;
        case 'G':
            cnt[2] += n;
            break;
        case 'T':
            cnt[3] += n;
            break;
        }
    };
    auto IsEnd = [](int *arr1, int *arr2, int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (arr1[i] > arr2[i])
                return false;
        }
        return true;
    };

    cin >> size >> length;
    cin >> str;
    cin >> condi[0] >> condi[1] >> condi[2] >> condi[3];

    for (int i = 0; i < length; i++)
        GetCount(cnt, str[i], 1);

    l = 0, r = length - 1;
    while (1)
    {
        if (IsEnd(condi, cnt, 4))
            count++;
        if (++r >= size)
            break;
        GetCount(cnt, str[l++], -1);
        GetCount(cnt, str[r], 1);
    }

    cout << count;

    return 0;
}