using System;

//행 열 입력
string[] inputs = Console.ReadLine().Split(' ');
int COL = int.Parse(inputs[0]); int ROW = int.Parse(inputs[1]);
int[,] map = new int[COL, ROW]; 
bool[,] flood = new bool[COL, ROW];
bool[,] HasPass = new bool[COL, ROW];

//맵 입력
Queue<coordination> queue = new Queue<coordination>();
for (int i = 0; i < COL; i++)
{
    string input = Console.ReadLine();
    for (int j = 0; j < ROW; j++) map[i, j] = input[j] - '0';
}


//메인
int totalWater = 0;
int MaxHeight = 9;
bool IsFlood = false;
int[] dx = { 0, 1, 0, -1 }; //상우하좌
int[] dy = { -1, 0, 1, 0 };
coordination current = new coordination();
Stack<coordination> stack = new Stack<coordination>();
bool IsInside(int ny, int nx) => (0 <= ny && 0 <= nx && ny < COL && nx < ROW);

for(int height = 1; height < 10; height++)
{
    for (int col = 0; col < COL; col++)
    {
        for (int row = 0; row < ROW; row++)
        {
            if (map[col, row] != height) continue;

            queue.Enqueue(new coordination { x = row, y = col });
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                HasPass[current.y, current.x] = true;
                stack.Push(current);

                for (int mv = 0; mv < 4; mv++)
                {
                    int nx = dx[mv] + current.x; int ny = dy[mv] + current.y;

                    if (IsInside(ny, nx))
                    {
                        if (height >= map[ny, nx] && !HasPass[ny, nx])
                        {
                            HasPass[ny, nx] = true;
                            queue.Enqueue(new coordination { x = nx, y = ny });
                        }
                        else
                        {
                            if(MaxHeight > map[ny, nx] && map[ny, nx] != height)
                            {
                                MaxHeight = map[ny, nx];
                            }
                        }
                    }
                    else//overflow water
                    {
                        IsFlood = true;
                    }
                }
            }

            if (IsFlood)
            {
                while (stack.Count > 0)
                {
                    current = stack.Pop();
                    flood[current.y, current.x] = true;
                }
                IsFlood = false;
            }
            else
            {
                while (stack.Count > 0)
                {
                    current = stack.Pop();
                    totalWater += MaxHeight - map[current.y, current.x];
                    map[current.y, current.x] = MaxHeight;
                }
            }           
            MaxHeight = 9;
            HasPass = new bool[COL, ROW];
        }
    }
}
Console.WriteLine(totalWater);

struct coordination { public int y; public int x; }