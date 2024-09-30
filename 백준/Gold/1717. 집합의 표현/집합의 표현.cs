using StreamWriter sw = new(Console.OpenStandardOutput());
var input = () => Console.ReadLine().Split().Select(int.Parse).ToList();
var A = input();
var set = Enumerable.Range(0, A[0] + 1).ToList();

while (A[1]-- > 0)
{
    var op = input();

    if (op[0] == 0)
    {
        union(op[1], op[2]);
    }
    else
    {
        sw.WriteLine(find(op[1]) == find(op[2]) ? "yes" : "no");
    }
}

void union(int k1, int k2)
{
    if (set[find(k1)] != set[find(k2)]) 
        set[find(k1)] = k2;
}

int find(int idx)
{
    if (set[idx] == idx)
    {
        return idx;
    }
    else
    {
        set[idx] = find(set[idx]);
        return set[idx];
    }
}