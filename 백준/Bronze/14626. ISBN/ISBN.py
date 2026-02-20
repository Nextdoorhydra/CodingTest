import sys

str = list(sys.stdin.readline())[:-1]
nums = [(1000 if x == '*' else int(x)) * (3 if (i + 1) % 2 == 0 else 1) for i, x in enumerate(str)]

s = sum(nums) % 1000
bias = (sum(nums) - s) // 1000

for i in range(10):
    if (s + bias * i) % 10 == 0:
        print(i)