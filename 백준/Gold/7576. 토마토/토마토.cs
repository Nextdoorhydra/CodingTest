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

        StringBuilder data = new StringBuilder();
        //박스 입력
        int idx = 0;
        for (int i = 0; i < COL; i++)
            data.Append(Console.ReadLine() + " ");

        for (int i = 0; i < data.Length; i++)
        {
            char c = data[i];
            if (c == ' ')
                continue;
            else if (c == '0')
                idx++;
            else if (c == '-')
            {
                BOX[idx++] = -1;
                i++; // Skip the next space
            }
            else if (c == '1')
                BOX[idx++] = 1;
        }

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
                IsAdjacent(queue.Dequeue());
            }
            COUNT++;

            //디버그용
            //display(); Console.WriteLine(" ... " + COUNT);
            //Console.WriteLine();
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

    static void display()
    {
        for (int i = 0; i < BOX.Length; i++)
        {
            if (i % ROW == 0) Console.WriteLine();
            Console.Write(BOX[i] + " ");
        }
    }
    static void IsAdjacent(int idx)
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