using System;

int N = int.Parse(Console.ReadLine());int[] seq = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int LENGTH = 1; int[] up = new int[N]; Array.Fill(up, 1);

for (int i = 0; i < N; i++) 
    for (int j = 0; j < i; j++)
        if (seq[i] > seq[j]) up[i] = Math.Max(up[i], up[j] + 1);

for (int i = 0; i < N; i++) LENGTH = Math.Max(LENGTH, up[i]);
Console.WriteLine(LENGTH);