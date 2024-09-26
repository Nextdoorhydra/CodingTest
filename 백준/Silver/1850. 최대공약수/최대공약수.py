def gcd(a, b):
    if(b == 0):
        return a
    return gcd(b, a % b)

n = list(map(int, input().split()))
n.sort(reverse=True)

print('1' * gcd(*n))