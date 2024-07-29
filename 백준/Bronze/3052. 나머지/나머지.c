#include<stdio.h>
#include<stdint.h>
#define DIV 42

int main() {
    uint64_t log = 0;
    int ans = 0;
    for (int i = 0; i < 10; i++) {
        int num;
        scanf("%d", &num);
        if ((log & (1ULL << (num % DIV))) == 0ULL) {
            ans++;
            log |= (1ULL << (num % DIV));
        }
    }
    printf("%d", ans);
    return 0;
}