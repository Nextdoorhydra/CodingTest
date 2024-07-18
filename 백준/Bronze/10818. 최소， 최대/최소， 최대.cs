using System;

class c10818
{
    static void Main(string[] args)
    {
        //조건 받는 곳
        string input = Console.ReadLine();
        int[] arr = new int[int.Parse(input)];

        //수열 받는 곳
        input = Console.ReadLine(); 
        string[] inputs = input.Split(' ');

        //문제 범위
        int min = 1000000; int max = -1000000;

        for(int i = 0; i < arr.Length; i++)
        {
            int num = int.Parse(inputs[i]);

            max = Math.Max(max, num);
            min = Math.Min(min, num);
        }

        Console.WriteLine($"{min} {max}");
    }
}