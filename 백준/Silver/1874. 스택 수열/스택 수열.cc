#include <iostream>
#include <stack>
#include <vector>
using namespace std;

int main()
{
    ios::sync_with_stdio(false); cin.tie(NULL); cout.tie(NULL);

    stack<int> st;
    vector<char> ans;
    int rep, n = 1, det;
    
    cin >> rep;

    for (int i = 0; i < rep; i++)
    {
        cin >> det;

        if (det >= n)
        {
            while (det >= n)
            {
                st.push(n++);
                ans.push_back('+');
            }
            st.pop();
            ans.push_back('-');
        }
        else
        {

            if (st.top() > det)
            {
                cout << "NO";
                return 0;
            }
            else
            {
                st.pop();
                ans.push_back('-');
            }
        }
    }

    for (auto c : ans)
    {
        cout << c << "\n";
    }

    return 0;
}