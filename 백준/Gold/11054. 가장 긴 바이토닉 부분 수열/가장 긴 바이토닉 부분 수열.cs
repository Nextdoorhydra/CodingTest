using System;
int LENGTH = 1;

int N = int.Parse(Console.ReadLine());
int[] seq = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int[] up = new int[N]; Array.Fill(up, 1); int[] down = new int[N]; Array.Fill(down, 1);

for (int i = 0; i < N; i++) 
    for (int j = 0; j < i; j++)
    {
        if (seq[i] > seq[j]) up[i] = Math.Max(up[i], up[j] + 1);
        if (seq[N - 1 - i] > seq[N - 1 - j]) down[N - 1 - i] = Math.Max(down[N - 1 - i], down[N - 1 - j] + 1);
    }
for (int i = 0; i < N; i++) LENGTH = Math.Max(LENGTH, up[i] + down[i]);

Console.WriteLine(LENGTH - 1);