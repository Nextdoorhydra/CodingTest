n = list(map(int, input().split()))
print('>' if n[0] > n[1] else '<' if n[1] > n[0] else '==')