using System;

//행 열 입력
string[] inputs = Console.ReadLine().Split(' ');
int COL = int.Parse(inputs[0]); int ROW = int.Parse(inputs[1]);

//맵 입력
int[,] map = new int[52, 52];
for (int i = 0; i < 52; i++) for (int j = 0; j < 52; j++) map[i, j] = 1; //1로 초기화
for (int i = 1; i <= COL; i++)
{
    string input = Console.ReadLine();
    for (int j = 1; j <= ROW; j++) map[i, j] = input[j - 1] - '0';
}

//메인
int totalWater = 0;
bool[,] visited = new bool[52, 52];
int[] dx = { 0, 1, 0, -1 }; int[] dy = { -1, 0, 1, 0 }; //상우하좌

coordination now = new coordination();
Queue<coordination> queue = new Queue<coordination>();

for(int height = 1; height < 10; height++)
{
    bfs(height);
    for (int i = 0; i < 52; i++) 
        for (int j = 0; j < 52; j++)
        {
            if (visited[i, j])
            {
                totalWater += height - map[i, j];
                map[i, j] = height + 1;
            }
        }
    visited = new bool[52, 52];
}

bool IsInside(int ny, int nx) => (0 <= ny && 0 <= nx && ny < 52 && nx < 52);

void bfs(int height)
{
    queue.Enqueue(new coordination { y = 0, x = 0});
    while(queue.Count > 0)
    {
        now = queue.Dequeue();
        for (int i = 0; i < 4; i++)
        {
            int nx = dx[i] + now.x; int ny = dy[i] + now.y;

            if(IsInside(ny, nx) && height >= map[ny, nx] && !visited[ny, nx])
            {
                visited[ny, nx] = true;
                queue.Enqueue(new coordination { y = ny, x = nx});
            }
        }
    }
}
Console.WriteLine(totalWater);

struct coordination { public int y; public int x; }