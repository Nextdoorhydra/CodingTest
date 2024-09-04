using System.ComponentModel.Design;
var input = Console.ReadLine().Split().ToList();
string N = input[0], target = input[1], ANS = "-1";

HashSet<string> visited = new();
var op = new[] { (string str) => (2 * long.Parse(str)).ToString(), (string str) => str + "1" };

DFS(N, 1);
Console.WriteLine(ANS);

void DFS(string N, int depth)
{
    visited.Add(N);

    if(N == target)
    {
        ANS = $"{depth}";
        return;
    }
    else if (long.Parse(N) < long.Parse(target))
    {
        foreach (var f in op)
        {
            var To = f(N);
            if (!visited.Contains(To))
                DFS(To, depth + 1);
        }
    }
}