using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security;

//투 포인터 알고리즘 사용
class c1806
{
    static int Range = 100001;
    static int N;
    static int S;
    static int SUM;
    static void Main(string[] args)
    {
        //조건 받는 곳
        string input = Console.ReadLine(); string[] inputs = input.Split(' ');
        N = int.Parse(inputs[0]); S = int.Parse(inputs[1]);

        //수열 받는 곳
        input = Console.ReadLine(); inputs = input.Split(' ');
        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            arr[i] = int.Parse(inputs[i]);
        }

        //투 포인터
        int left = 0; int right = 0;

        SUM = arr[right];
        while (left <= right)
        {
            if (SUM >= S)
            {
                if(right - left + 1< Range)
                    Range = right - left + 1;
                SUM -= arr[left++];
            }
            else
            {
                if (++right >= N) break;
                SUM += arr[right];
            }
        }
        Console.WriteLine(Range != 100001 ? Range : 0);
    }
}