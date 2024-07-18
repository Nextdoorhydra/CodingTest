#include<iostream>

int main()
{
    std::string input;
    std::cin >> input; 
    std::cin >> input;

    int sum = 0;
    for(char n : input) sum += n - '0';

    std::cout << sum << std::endl;
    return 0;
}