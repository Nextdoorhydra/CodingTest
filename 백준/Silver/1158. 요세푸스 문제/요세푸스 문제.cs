using System;

string[] inputs = Console.ReadLine().Split(" ");
int N = int.Parse(inputs[0]); int K = int.Parse(inputs[1]);

int now = 1;
int[] table = new int[N];
List<int> per = new List<int>();
for (int i = 0; i < N; i++) table[i] = now++;

now = 0;
while(per.Count < N)
{
    int i = 0;
    while(i < K)
    {
        if (table[now] != 0) i++;
        now = ++now % N;
    }
    per.Add(table[now == 0 ? N - 1 : now - 1]);
    table[now == 0 ? N - 1 : now - 1] =0;
}
Console.Write("<");
for(int i = 0; i < N - 1; i++) Console.Write(per[i] + ", ");
Console.WriteLine(per[per.Count - 1] + ">");