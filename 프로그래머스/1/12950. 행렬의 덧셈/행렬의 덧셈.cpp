#include <string>
#include <vector>

using namespace std;

vector<vector<int>> solution(vector<vector<int>> arr1, vector<vector<int>> arr2)
{
    auto matrixSum = [](const vector<vector<int>>& m1, const vector<vector<int>>& m2) -> vector<vector<int>>
        {
            vector<vector<int>> sum(m1.size(), vector(m1[0].size(), 0));
            for (int c = 0; c < m1.size(); c++)
            {
                for (int r = 0; r < m1[0].size(); r++)
                {
                    sum[c][r] = m1[c][r] + m2[c][r];
                }
            }

            return sum;
        };

    return matrixSum(arr1, arr2);
}