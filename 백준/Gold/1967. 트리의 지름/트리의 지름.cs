int rep = int.Parse(Console.ReadLine());
var Tree = Enumerable.Range(1, rep + 1).Select((x, i) => new tree(i)).ToArray();

for(int i = 0; i < rep - 1; i++)
{
    var input = Console.ReadLine().Split().Select(int.Parse).ToList();
    int parent = input[0], children = input[1], weight = input[2];
    Tree[parent].AddEdge(Tree[children], weight);
    Tree[children].AddEdge(Tree[parent], weight);
}

tree.printMaxRadius(Tree);

class tree
{
    public int id;
    public List<edge> edgeList = new();
    public List<int> maxWeights = new();
    public static HashSet<int> visited = new();

    public tree(int id) => this.id = id;

    public void AddEdge(tree To, int weight) => edgeList.Add(new edge(To, weight));

    public static void printMaxRadius(tree[] Tree)
    {
        setAdjacencyDistance(Tree[1], 0);
        int max = 0;
        foreach(var node in Tree)
            max = Math.Max(node.maxWeights.Take(2).Sum(), max);
        Console.WriteLine(max);
    }

    public static int setAdjacencyDistance(tree node, int radius)
    {
        visited.Add(node.id);
        node.maxWeights.AddRange(new[] { 0, 0 } );

        foreach(var next in node.edgeList)
        {
            if(!visited.Contains(next.To.id))
            {
                node.maxWeights.Add(setAdjacencyDistance(next.To, next.weight));
            }
        }
        node.maxWeights.Sort((x, y) => y.CompareTo(x));
        return node.maxWeights[0] + radius;
    }

    public class edge
    {
        public int weight { get; private set; }
        public tree To;

        public edge(tree To, int weight)
        {
            this.To = To;
            this.weight = weight;
        }
    }
}