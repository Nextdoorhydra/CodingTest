using System;

string[] inputs = Console.ReadLine().Split(" ");

int N = int.Parse(inputs[0]); int M = int.Parse(inputs[1]);

//변수
int answer = 0;
List<List<int>> edge = new List<List<int>>();
int[] who = new int[M]; Array.Fill(who, -1);
bool[] visited = new bool[M];

for (int i = 0; i < N; i++)
{
    inputs = Console.ReadLine().Split(" ");
    edge.Add(new List<int>());

    int max = int.Parse(inputs[0]);
    for (int j = 0; j < max; j++) edge[i].Add(int.Parse(inputs[j + 1]) - 1);
}

for (int i = 0; i < N; i++)
{
    if (dfs(i)) answer++;
    visited = new bool[M];
}
Console.WriteLine(answer);

bool dfs(int n)
{
    foreach(int i in edge[n])
    {
        if (visited[i]) continue;
        visited[i] = true;

        if (who[i] == -1 || dfs(who[i]))
        {
            who[i] = n;
            return true;
        }
    }
    return false;
}