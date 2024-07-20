using System;
using System.Text;

string[] inputs = Console.ReadLine().Split(' ');

int COL = int.Parse(inputs[0]); int ROW = int.Parse(inputs[1]);
//정의
int[,] map = new int[COL, ROW]; int[,] arr = new int[COL, ROW];
Queue<coordination> queue = new Queue<coordination>();
coordination current = new coordination();
int[] dy = { 0, 1, 0, -1 }; int[] dx = { 1, 0, -1, 0 };
bool IsInside(int ny, int nx) => (0 <= ny && 0 <= nx && ny < COL && nx < ROW);

//맵 저장
Input();
for (int i = 0; i < COL; i++)
{
    for (int j = 0; j < ROW; j++)
    {
        if (map[i, j] == (int)state.passable)
        {
            arr[i, j] = (int)state.unvisited;
        } else if (map[i, j] == (int)state.departure)
        {
            current.y = i; current.x = j;
            arr[current.y, current.x] = 0;
        }
    }
}

//메인
queue.Enqueue(current);
while(queue.Count > 0)
{
    current = queue.Dequeue();
    for (int i = 0; i < 4; i++)
    {
        int ny = current.y + dy[i]; int nx = current.x + dx[i];
        if (IsInside(ny, nx) && map[ny, nx] == (int)state.passable)
        {
            if(arr[ny, nx] == (int)state.unvisited || arr[ny, nx] > arr[current.y, current.x] + 1)
            {
                arr[ny, nx] = arr[current.y, current.x] + 1;
                coordination next;
                next.y = ny ; next.x = nx;
                queue.Enqueue(next);
            }
        }
    }
}
display();

void Input()
{
    for (int i = 0; i < COL; i++)
    {
        inputs = Console.ReadLine().Split(' ');
        for (int j = 0; j < ROW; j++) map[i, j] = int.Parse(inputs[j]);
    }
}

void display()
{
    StringBuilder output = new StringBuilder();

    for (int i = 0; i < COL; i++)
    {
        for (int j = 0; j < ROW; j++)
        {
            output.Append(arr[i, j]).Append(" ");
        }
        output.AppendLine();
    }
    Console.Write(output.ToString());
}
struct coordination { public int y; public int x; }
enum state { unvisited = -1, obstacle, passable, departure }