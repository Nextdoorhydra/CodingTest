import sys, enum, itertools

# declaration
input = sys.stdin.readline
class Cell(enum.IntEnum):
    SAFE = 0
    WALL = 1
    VIRUS = 2    
answer = 0
dr, dc = [-1, 1, 0, 0], [0, 0, -1, 1]
lab, sample, virus = [], [], []
countSafe = lambda lab: sum(row.count(Cell.SAFE) for row in lab)
isSpreadable = lambda r, c: 0 <= r < N and 0 <= c < M and lab[r][c] == Cell.SAFE

# input
N, M = map(int, input().split())
lab = [list(map(lambda x: Cell(int(x)), input().split())) for _ in range(N)]

# logic
for r in range(N):
    for c in range(M):
        if lab[r][c] == Cell.VIRUS:
            virus.append((r, c))
        elif lab[r][c] == Cell.SAFE:
            sample.append((r, c))

for walls in itertools.combinations(sample, 3):
    # sample 3 walls
    for r, c in walls:
        lab[r][c] = Cell.WALL

    # spread virus
    for r, c in virus:
        stack = [(r, c)]
        while stack:
            r, c = stack.pop()
            for i in range(4):
                nr, nc = r + dr[i], c + dc[i]
                if isSpreadable(nr, nc):
                    lab[nr][nc] = Cell.VIRUS
                    stack.append((nr, nc))
            
    answer = max(answer, countSafe(lab))   

    # reset lab
    for r in range(N):
        for c in range(M):
            if lab[r][c] == Cell.VIRUS and (r, c) not in virus:
                lab[r][c] = Cell.SAFE
            elif (r, c) in walls:
                lab[r][c] = Cell.SAFE

# output
print(answer)