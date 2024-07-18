using System;

class c2562
{
    static int Range = 9;
    static void Main(string[] args)
    {
        int[] arr = new int[Range];
        for(int i = 0; i < Range; i++)
        {
            string input = Console.ReadLine();
            arr[i] = int.Parse(input);
        }

        int idx = 0;
        int max = arr[idx];
        for(int i = 1; i < arr.Length; i++)
        {
            if(max < arr[i])
            {
                idx = i;
                max = arr[idx];
            }
        }
        Console.WriteLine($"{max}\n{idx + 1}");
    }
}