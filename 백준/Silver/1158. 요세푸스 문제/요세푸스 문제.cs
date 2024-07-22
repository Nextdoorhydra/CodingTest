using System;
using System.Text;

string[] inputs = Console.ReadLine().Split(" ");
int N = int.Parse(inputs[0]); int K = int.Parse(inputs[1]);

int now = 1;
int[] table = new int[N]; 
for (int i = 0; i < N; i++) table[i] = now++; now = 0;

List<int> per = new List<int>();
Func<int, int> idx = (now) => { int n = now == 0 ? N - 1 : now - 1; return n; };
while(per.Count < N)
{
    int i = 0;
    while(i < K)
    {
        if (table[now] != 0) i++;
        now = ++now % N;
    }
    per.Add(table[idx(now)]);
    table[idx(now)] = 0;
}

StringBuilder sb = new StringBuilder();
sb.Append("<"); for(int i = 0; i < N - 1; i++) sb.Append(per[i] + ", "); sb.Append(per[per.Count - 1] + ">");
Console.WriteLine(sb);