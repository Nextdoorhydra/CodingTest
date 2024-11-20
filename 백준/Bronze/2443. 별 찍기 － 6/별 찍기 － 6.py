N = int(input())

for i in range(N):
    print(f"{' ' * i}{'*' * (2 * (N - i - 1) + 1)}")