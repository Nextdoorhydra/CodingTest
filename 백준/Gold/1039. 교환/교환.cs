var input = Console.ReadLine().Split().ToList();
string number = input[0];
int k = int.Parse(input[1]);

var combinations = getCombination(input[0].Length);
HashSet< (string str, int depth)> visited = new();
Queue<(string str, int depth)> queue = new();
var swap = (string str, (int k1, int k2) c) =>
{
    var chars = str.ToCharArray();
    (chars[c.k1], chars[c.k2]) = (chars[c.k2], chars[c.k1]);
    return new string(chars);
};

int answer = -1;

bfs(number, k);

void bfs(string number, int depth)
{
    queue.Enqueue((number, 0));

    while (queue.Count > 0)
    {
        var now = queue.Dequeue();

        if(now.depth == depth)
        {
            answer = Math.Max(answer, int.Parse(now.str));
            continue;
        }
        else if (visited.Contains((now.str, now.depth)))
        {
            continue;
        }

        visited.Add((now.str, now.depth));

        foreach(var C in combinations)
        {
            var nextStr = swap(now.str, C);
            if (nextStr[0] == '0') continue;

            queue.Enqueue((nextStr, now.depth + 1));
        }
    }
}

Console.WriteLine(answer);

List<(int, int)> getCombination(int k)
{
    List<(int, int)> combinations = new();

    for(int i = 3; i < Math.Pow(2, k); i++)
    {
        int cnt = 0;
        List<int> ls = new();
        for(int j = 0; j <= k;  j++)
        {
            if((i & (1 << j)) != 0)
            {
                cnt++;
                ls.Add(j);
            }
        }
        if(cnt == 2)
        {
            combinations.Add((ls[0], ls[1]));
        }
    }
    return combinations;
}