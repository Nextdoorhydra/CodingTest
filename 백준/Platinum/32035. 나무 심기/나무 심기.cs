using System.Collections;
using System.Text;

class c32035
{
    static int ROW = 1; static int COL = 1;
    static StringBuilder sb = new StringBuilder();
    static void Main(string[] args)
    {
        // 사용자로부터 입력 받기
        string input = Console.ReadLine();
        string[] inputs = input.Split(' ');

        // 문자열 배열의 각 요소를 정수로 변환
        int even = int.Parse(inputs[0]);
        int odd = int.Parse(inputs[1]);

        //case0 반례 4m + 3n (m >=1, n>=0) (0, 0) (2, 0) (3, 0) (5, 0) (6, 0) (9, 0)
        if(odd == 0)
        {
            if(even == 0 || even == 2 || even == 3 || even == 5 || even == 6 || even == 9) 
            {
                Console.WriteLine("NO"); return;
            }
        }
        if (odd % 2 != 0)
        {
            Console.WriteLine("NO"); return;
        }
        //case1: loop
        if (odd == 0)
        {
            int fourLoop = 0; int threeLoop = 0;
            int temp = even != 1 ? even : 0;
            while (temp % 4 != 0)
            {
                temp -= 3; threeLoop++;
            }
            fourLoop = temp / 4;

            Console.WriteLine("YES");
            //출력 함수
            ROW = COL = 1 + fourLoop  + threeLoop;
            int[] map = new int[ROW * COL];
            //draw fourLoop
            int idx;
            for(idx = 0; idx < fourLoop * (ROW + 1) + 1; idx++)
            {
                //뚜껑
                if(idx < fourLoop + 1 || idx / ROW == fourLoop)
                {
                    map[idx] = 1;
                }
                //벽
                else if (idx % ROW == 0 || (idx - fourLoop) % ROW == 0)
                {
                    map[idx] = 1;
                }
            }
            //draw threeLoop
            for(int i = 0; i < threeLoop; i++)
            {
                map[idx - 1 + i] = 1; map[idx - 1 + ROW + i] = 1;
                map[idx + i] = 1; map[idx + ROW + i] = 1;
                idx += ROW;
            }
            display(map);
            return;
        }
        //case2: string
        else
        {
            Console.WriteLine("YES");
            //출력 함수
            ROW = COL = even + odd / 2 + 1;
            int[] map = new int[ROW * COL];
            bool flag = true;
            //맵 작성
            int idx;
            for(idx = 1;  idx < ROW * (odd / 2 + 1); idx += ROW)
            {
                map[idx] = 1;
                if (idx == 1 || idx + ROW > ROW * (odd / 2 + 1)) continue;
                if(flag)
                {
                    flag = false;
                    map[idx - 1] = 1;
                }
                else
                {
                    flag = true;
                    map[idx + 1] = 1;
                }
            }
            for(; idx < map.Length; idx += ROW)
            {
                map[idx] = 1;
            }
            display(map);
            return;
        }

    }

    static void display(int[] map)
    {
        Console.WriteLine($"{ROW} {COL}");
        for (int i = 0; i < map.Length; i++)
        {
            if(i % ROW == 0 && i != 0) sb.Append("\n");
            switch (map[i])
            {
                case 0: sb.Append("."); break;
                case 1: sb.Append("O"); break;
            }
        }
        Console.WriteLine(sb.ToString());
    }
}