put = lambda: map(int, input().split());
n, m = put()
arrive = False;
relations = [[] for _ in range(n)]
visited = [False] * n

def dfs(v, depth):
    global arrive
    visited[v] = True

    if arrive or depth == 5:
        arrive = True
        return

    for i in relations[v]:
        if not visited[i]:
            dfs(i, depth + 1)

    visited[v] = False

for i in range(m):
    v1, v2 = put()
    relations[v1].append(v2)
    relations[v2].append(v1)

for i in range(n):
    dfs(i, 1)

print(1 if arrive else 0)