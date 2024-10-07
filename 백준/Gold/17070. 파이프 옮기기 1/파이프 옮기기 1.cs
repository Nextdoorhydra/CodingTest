using static State;
var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
int N = read()[0], ANSWER = 0;
List<List<int>> map = Enumerable.Range(0, N).Select(x => read()).ToList();

var rangeCheck = (Position x) => x.pos.r >= 0 && x.pos.r < N && x.pos.c >= 0 && x.pos.c < N;
var obstacleCheck = (Position x) => x.state switch 
{ 
    DIAGONAL => map[x.pos.r][x.pos.c] != 1 
    && map[x.pos.r - 1][x.pos.c] != 1 
    && map[x.pos.r][x.pos.c - 1] != 1,
    _ => map[x.pos.r][x.pos.c] != 1
};

var moves = new List<Func<Position, Position>>[]
{
    //WIDTH
    new List<Func<Position, Position>>
    {
        (Position x) => new Position(WIDTH, x.add((0, 1))),
        (Position x) => new Position(DIAGONAL, x.add((1, 1)))
    },

    //HEIGHT
    new List<Func<Position, Position>>
    {
        (Position x) => new Position(HEIGHT, x.add((1, 0))),
        (Position x) => new Position(DIAGONAL, x.add((1, 1)))
    },

    //DIAGONAL
    new List<Func<Position, Position>>
    {
        (Position x) => new Position(WIDTH, x.add((0, 1))),
        (Position x) => new Position(HEIGHT, x.add((1, 0))),
        (Position x) => new Position(DIAGONAL, x.add((1, 1)))
    }
};

//main
dfs(new Position(WIDTH, (0, 1)));
Console.WriteLine(ANSWER);

void dfs(Position now)
{
    if (now.pos == (N - 1, N - 1)) ANSWER++;
    foreach (var move in moves[(int)now.state])
    {
        var next = move(now);
        if (rangeCheck(next) && obstacleCheck(next)) dfs(next);
    }
}

//struct, enum
enum State { WIDTH, HEIGHT, DIAGONAL }
struct Position
{
    public State state;
    public (int r, int c) pos;
    public Position(State state, (int r, int c) pos)
    {
        this.state = state;
        this.pos = pos;
    }
    public (int r, int c) add((int r, int c) x) => (pos.r + x.r, pos.c + x.c);
}