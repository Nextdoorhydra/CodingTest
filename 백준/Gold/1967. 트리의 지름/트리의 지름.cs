int rep = int.Parse(Console.ReadLine());
var Tree = Enumerable.Range(1, rep + 1).Select((x, i) => new tree(i)).ToArray();

for(int i = 0; i < rep - 1; i++)
{
    var input = Console.ReadLine().Split().Select(int.Parse).ToList();
    int parent = input[0], children = input[1], weight = input[2];
    Tree[parent].AddEdge(Tree[children], weight);
    Tree[children].AddEdge(Tree[parent], weight);
}

tree.FindMaxRadius(Tree);

class tree
{
    public int id;
    public List<edge> edgeList;
    public static int answer = 0;
    public static HashSet<int> visited = new HashSet<int>();

    public tree(int id)
    {
        this.id = id;
        edgeList = new List<edge>();
    }

    public void AddEdge(tree To, int weight)
    {
        edgeList.Add(new edge(To, weight));
    }

    public static void FindMaxRadius(tree[] Tree)
    {
        foreach(var tree in Tree.Skip(1))
        {
            DFS(tree, 0);
            visited.Clear();
        }
        Console.WriteLine(answer);
    }

    public static void DFS(tree root, int radius)
    {
        visited.Add(root.id);

        foreach (var next in root.edgeList)
        {
            if (!visited.Contains(next.To.id)) 
                DFS(next.To, next.weight + radius);
        }

        answer = Math.Max(answer, radius);
    }

    public class edge
    {
        public int weight;
        public tree To;

        public edge(tree To, int weight)
        {
            this.To = To;
            this.weight = weight;
        }
    }
}