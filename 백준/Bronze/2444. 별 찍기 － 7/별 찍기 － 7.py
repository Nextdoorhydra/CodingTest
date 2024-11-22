N = int(input())

for i in range(N):
    print(f"{' ' * (N - i - 1)}{'*' * (2 * i + 1)}")
for i in range(N):
    if i == 0:
        continue
    print(f"{' ' * i}{'*' * (2 * (N - i - 1) + 1)}")