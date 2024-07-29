#include<stdio.h>
#include<stdint.h>

int main() {
    uint64_t log = 0;
    int ans = 0;
    for (int i = 0; i < 10; i++) {
        int num;
        scanf("%d", &num);
        uint64_t pos = 1ULL << (num % 42);
        if ((log & pos) == 0ULL) {
            ans++;
            log |= pos;
        }
    }
    printf("%d", ans);
    return 0;
}