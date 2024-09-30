var input = () => Console.ReadLine().Split().Select(int.Parse).ToList();
var A = input();
int V = A[0], E = A[1];
List<long> MST = new();
List<int> set = Enumerable.Range(0, V + 1).ToList();
List<List<int>> edgeList = Enumerable.Range(0, E).Select(_ => input()).ToList().OrderBy(x => x.Last()).ToList();

int find(int x) => set[x] == x ? x : set[x] = find(set[x]);
bool union(int x, int y) 
{ 
    int a = find(x), b = find(y);
    if(a != b)
    {
        set[a] = b;
        return true;
    } 
    return false;
}

while(true)
{
    foreach(var edge in edgeList)
    {
        if(MST.Count == V - 1)
        {
            Console.WriteLine(MST.Sum());
            return;
        }

        if (union(edge[0], edge[1])) MST.Add(edge[2]);
    }
}