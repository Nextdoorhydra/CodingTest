using System;

class c13140
{
    static int NUMBER;
    static int[] answer = new int[5];
    static int[] table = new int[7];
    static character ch = new character();
    struct character
    {
        public int h;
        public int w;
        public int e;
        public int o;
        public int l;
        public int r;
        public int d;
    }
    static void Main(string[] args)
    {
        int[,] map = new int[2, 5];
        string input = Console.ReadLine();

        //최대, 최소 반례
        NUMBER = int.Parse(input);
        if (NUMBER > 184010 || NUMBER < 33986) goto OUT; //종료

        //main
        HashSet<int> visited = new HashSet<int>();
        if(recursion(visited, map))
        {
            display(map); return;
        }

    OUT: Console.WriteLine("No Answer");
    }
    static bool recursion(HashSet<int> visited, int[,] map)
    {
        if (visited.Count == 7)
        {
            sync(visited, map);
            if(IsPossible(map))
            {
                return true;
            }
            return false;
        }
        int i = visited.Count <= 1 ? 1 : 0;
        for (; i < 10; i++)
        {
            if (visited.Contains(i)) continue;
            visited.Add(i);
            if(recursion(visited, map))
            {
                return true;
            }
            visited.Remove(i);
        }
        return false;
    }
    static bool IsPossible(int[,] map)
    {
        int[] sum = { 0, 0 };
        for(int i = 0; i < 2; i++)
        {
            int mul = 1;
            for(int j = 4; j >= 0; j--)
            {
                sum[i] += map[i, j] * mul;
                mul *= 10;
            }
        }
        if (sum[0] + sum[1] == NUMBER) return true;
        return false;
    }
    static void sync(HashSet<int> visited, int[,] map)
    {
        List<int> list = visited.ToList();

        ch.h = list[0];
        ch.w = list[1];
        ch.e = list[2];
        ch.l = list[3];
        ch.o = list[4];
        ch.r = list[5];
        ch.d = list[6];
        map[0, 0] = ch.h; map[1, 0] = ch.w;
        map[0, 1] = ch.e; map[1, 1] = ch.o;
        map[0, 2] = ch.l; map[1, 2] = ch.r;
        map[0, 3] = ch.l; map[1, 3] = ch.l;
        map[0, 4] = ch.o; map[1, 4] = ch.d;
    }
    static void display(int[,] map)
    {
        Console.WriteLine($"  {map[0, 0]}{map[0, 1]}{map[0, 2]}{map[0, 3]}{map[0, 4]}\n" +
            $"+ {map[1, 0]}{map[1, 1]}{map[1, 2]}{map[1, 3]}{map[1, 4]}\n" +
            "-------");
        if(NUMBER > 99999)
        {
            Console.WriteLine($" {NUMBER}");
        }
        else
        {
            Console.WriteLine($"  {NUMBER}");
        }
    }
}