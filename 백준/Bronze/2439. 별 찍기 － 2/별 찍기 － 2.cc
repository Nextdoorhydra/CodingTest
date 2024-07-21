#include<iostream>
using namespace std;

int main(){
    int max;
    cin >> max;
    for(int i = 1; i <= max; i++){
        for(int j = i; j < max; j++) cout << ' ';
        for(int j = max - i; j < max; j++) cout << '*'; cout << endl;
    }
    return 0;
}