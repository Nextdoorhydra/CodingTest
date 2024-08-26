using StreamWriter sw = new(Console.OpenStandardOutput());
dfs(new List<int>(), Array.ConvertAll(Console.ReadLine().Split(), int.Parse), 0);

void dfs(List<int> ls, int[] condi, int depth)
{
    if (depth == condi[1])
        sw.WriteLine(string.Join(" ", ls));
    else
    {
        for (int i = 1; i <= condi[0]; i++)
        {
            var next = new List<int>(ls);

            if(next.Count == 0 || next.Last() <= i)
            {
                next.Add(i);
                dfs(next, condi, depth + 1);
            }
        }
    }
}