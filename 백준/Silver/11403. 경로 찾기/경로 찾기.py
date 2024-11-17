INF = 101
N = int(input())
adj = [[x for x in map(int, input().split())] for _ in range(N)]

for i in range(N):
    for j in range(N):
        if adj[i][j] == 0:
            adj[i][j] = INF
            
            
for k in range(N):
    for s in range(N):
        for e in range(N):
            adj[s][e] = min(adj[s][e], adj[s][k] + adj[k][e])
         
for row in adj:
    print(' '.join(map(str,  [0 if x == INF else 1 for x in row])))