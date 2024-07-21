#include<stdio.h>

int IsDoom(int doom)
{
    int doomCount = 0;
    while(doom > 0 && doomCount < 3){
        if(doom % 10 == 6) {
            doomCount++;
        }
        else doomCount = 0;
        doom /= 10;
    }
    if(doomCount == 3) return 1;
    return 0;
}

int main()
{
    int ans; scanf("%d", &ans);

    int NumberofDoom = 0; int doom = 666;

    while(1){
        if(IsDoom(doom)) NumberofDoom++;
        if(NumberofDoom == ans) break;
        doom++;
    }

    printf("%d", doom);
}