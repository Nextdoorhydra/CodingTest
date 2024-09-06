using System.Runtime.Intrinsics.X86;

int rep = int.Parse(Console.ReadLine());
long count = 0;
List<int> A = new(), B = new(), C = new(), D = new();

for (int i = 0; i < rep; i++)
{
    var input = Console.ReadLine().Split().Select(int.Parse).ToList();
    A.Add(input[0]);
    B.Add(input[1]);
    C.Add(input[2]);
    D.Add(input[3]);
}

var set1 = foo(A, B);
var set2 = foo(C, D);

for(int i = 0; i < set1.Count; i++)
{
    int key = set1[i];
    long cnt = 1;

    while (i < set1.Count - 1 && set1[i + 1] == key)
    {
        i++;
        cnt++;
    }

    int cnt2 = FindUpperBound(set2, -key);

    if(cnt2 >= 0)
    {
        int cnt3 = FindLowerBound(set2, -key);
        cnt2 += - cnt3 - 1;
    }
    else
    {
        cnt2 = 0;
    }

    count += cnt * cnt2;
}

Console.WriteLine(count);

List<int> foo(List<int> A, List<int> B)
{
    var set = A.SelectMany(a => B, (a, b) => a + b).ToList();
    set.Sort();
    return set;
}

int FindUpperBound(List<int> source, int value)
{
    int index = source.BinarySearch(value);
    if (index >= 0)
    {
        while (index < source.Count && source[index] == value)
        {
            index++;
        }
    }
    return index;
}

int FindLowerBound(List<int> source, int value)
{
    int index = source.BinarySearch(value);
    if (index >= 0)
    {
        while (index >= 0 && source[index] == value)
        {
            index--;
        }
    }
    return index;
}