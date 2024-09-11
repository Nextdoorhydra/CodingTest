#include <iostream>
#include <vector>
#include <sstream>
using namespace std;

vector<string> split(const string& str, char delimiter){
    vector<string> result;
    stringstream SS(str);
    string splitData;

    while(getline(SS, splitData, delimiter)){
        result.push_back(splitData);
    }
    return result;
}

int returnSum(const string& str){
    int sum = 0;
    vector<string> splitByPlusString = split(str, '+');
        for(auto s : splitByPlusString){
            sum += stoi(s);
        }
    return sum;
}

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    int answer = 0;
    string str;
    cin >> str;

    vector<string> splitByMinusString = split(str, '-');

    for(int i = 0; i < splitByMinusString.size(); i++){
        int sum = returnSum(splitByMinusString[i]);
        if(i == 0){
            answer += sum;
        }else{
            answer -= sum;
        }
    }

    cout << answer;
}