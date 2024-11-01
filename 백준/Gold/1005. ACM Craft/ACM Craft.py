import sys
import queue

read = lambda: map(int, sys.stdin.readline().rstrip().split())
T = int(sys.stdin.readline().rstrip())

for rep in range(T):
    q = queue.Queue()
    N, K = read()
    parent = [0] * N
    lapse = [0] * N
    edgeList = [[] for _ in range(N)]
    D = list(read())
    
    for i in range(K):
        edge = list(read())
        parent[edge[1] - 1] += 1
        edgeList[edge[0] - 1].append(edge[1] - 1)
    
    W = int(sys.stdin.readline().rstrip()) - 1
    
    for x in [idx for idx, val in enumerate(parent) if val == 0]:
        q.put(x)
        lapse[x] = D[x]
        
    while not q.empty():
        x = q.get()

        for next in edgeList[x]:
            parent[next] -= 1
            lapse[next] = max(lapse[next], lapse[x])
            
            if parent[next] == 0:
                lapse[next] += D[next]
                q.put(next)
                
    sys.stdout.write(str(lapse[W]) + '\n')