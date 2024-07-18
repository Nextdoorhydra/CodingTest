using System;
using System.Text;

class c7576
{
    static int ROW;
    static int COL;
    static int COUNT;
    static int[] BOX;
    static Queue<int> queue = new Queue<int>();
    enum State
    {
        block = -1, raw = 0, full = 1
    }
    static void Main(String[] args)
    {

        //열, 행 입력
        string input = Console.ReadLine();
        string[] inputs = input.Split(' ');
        ROW = int.Parse(inputs[0]);
        COL = int.Parse(inputs[1]);
        BOX = new int[ROW * COL];
        //박스 입력
        int _idx = 0;
        for (int i = 0; i < COL; i++)
        {
            input = Console.ReadLine();
            inputs = input.Split(' ');
            for (int j = 0; j < ROW; j++)
                BOX[_idx++] = int.Parse(inputs[j]);
        }

        //초기 큐
        for (int i = 0; i < BOX.Length; i++)
            if ((State)BOX[i] == State.full)
            {
                queue.Enqueue(i);
            }

        //메인 로직
        while (queue.Count > 0)
        {
            int range = queue.Count;
            for (int i = 0; i < range; i++)
            {
                int idx = queue.Dequeue();
                {
                    Action<int> IsAdjacency = (idx) =>
                    {
                        if ((State)BOX[idx] == State.raw)
                        {
                            queue.Enqueue(idx);
                            BOX[idx] = (int)State.full;
                        }
                    };
                    //오른쪽으로
                    if (idx % ROW != ROW - 1)
                        IsAdjacency(idx + 1);
                    //왼쪽으로
                    if (idx % ROW != 0)
                        IsAdjacency(idx - 1);
                    //위로
                    if (idx - ROW >= 0)
                        IsAdjacency(idx - ROW);
                    //아래로
                    if (idx + ROW < BOX.Length)
                        IsAdjacency(idx + ROW);
                }
            }
            COUNT++;
        }

        //최종 결과 출력
        for(int i = 0; i < BOX.Length; i++) 
        { 
            if (BOX[i] == 0)
            {
                Console.WriteLine(-1);
                return;
            } 
        }
        Console.WriteLine(--COUNT);
    }
}