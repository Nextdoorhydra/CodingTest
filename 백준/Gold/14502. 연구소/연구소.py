import sys, itertools

# declaration
input = sys.stdin.readline
SAFE, WALL, VIRUS = 0, 1, 2 
answer, initSafe = 0, 0
dr, dc = [-1, 1, 0, 0], [0, 0, -1, 1]
lab, sample, virus, spreadList = [], [], [], []
countSafe = lambda lab: sum(row.count(SAFE) for row in lab)
isSpreadable = lambda r, c: 0 <= r < N and 0 <= c < M and lab[r][c] == SAFE

# input
N, M = map(int, input().split())
lab = [list(map(int, input().split())) for _ in range(N)]

# logic
for r in range(N):
    for c in range(M):
        if lab[r][c] == VIRUS:
            virus.append((r, c))
        elif lab[r][c] == SAFE:
            sample.append((r, c))
            initSafe += 1

for walls in itertools.combinations(sample, 3):
    # sample 3 walls
    for r, c in walls:
        lab[r][c] = WALL

    # spread virus
    spreadList.clear()
    
    for r, c in virus:
        stack = [(r, c)]
        while stack:
            r, c = stack.pop()
            for i in range(4):
                nr, nc = r + dr[i], c + dc[i]
                if isSpreadable(nr, nc):
                    lab[nr][nc] = VIRUS
                    stack.append((nr, nc))
                    spreadList.append((nr, nc))
            
    answer = max(answer, initSafe - len(spreadList) - 3)

    # reset lab
    for r, c in spreadList:
        lab[r][c] = SAFE
    for r, c in walls:
        lab[r][c] = SAFE

# output
print(answer)