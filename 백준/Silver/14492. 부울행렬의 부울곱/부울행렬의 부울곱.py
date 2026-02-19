import sys

input = sys.stdin.readline
dot = lambda a, b: sum(x * y for x, y in zip(a, b))
transpose = lambda m: list(zip(*m))

n = int(input())
m1 = [list(map(int, input().split())) for _ in range(n)]
m2 = [list(map(int, input().split())) for _ in range(n)]
m3 = [[dot(row, col) for col in transpose(m2)] for row in m1]

print(len([x for row in m3 for x in row if x > 0]))