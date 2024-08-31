var g = new graph(Array.ConvertAll(Console.ReadLine().Split(), int.Parse));

Console.WriteLine(g.arrive ? 1 : 0);

class graph
{
    List<List<int>> relations;
    bool[] visited;
    public bool arrive { get; private set; }

    public graph(int[] input)
    {
        //set ralations
        relations = Enumerable.Range(0, input[0]).Select(x => new List<int>()).ToList();
        for (int i = 0; i < input[1]; i++)
        {
            var _input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            relations[_input[0]].Add(_input[1]);
            relations[_input[1]].Add(_input[0]);
        }
        visited = new bool[input[0]];
        arrive = false;

        for(int i = 0; i < input[0]; i++)
        {
            if(!arrive) hasFiveLoop(i, 1);
        }
    }

    void hasFiveLoop(int v, int depth)
    {
        visited[v] = true;

        if (depth is 5 || arrive)
        {
            arrive = true;
            return;
        }

        foreach (var next in relations[v])
        {
            if (!visited[next])
                hasFiveLoop(next, depth + 1);
        }

        visited[v] = false;
    }
}