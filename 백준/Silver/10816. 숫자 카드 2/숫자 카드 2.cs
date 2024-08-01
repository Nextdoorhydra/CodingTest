using System.Text;

StringBuilder sb = new StringBuilder();

int size1 = int.Parse(Console.ReadLine());
var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int size2 = int.Parse(Console.ReadLine());
var arr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

var number = new int[20000001];

Func<int, int> In = x => x >= 0 ? x : 10000000 - x; //10000000 부터 -1, -2, ...

for (int i = 0; i < size1; i++)
{
    int idx = In(arr[i]);
    number[idx]++;
}

int[] ans = new int[size2];

for (int i = 0; i < size2; i++)
{
    int idx = In(arr2[i]);
    ans[i] = number[idx];
}

Console.WriteLine(string.Join(" ", ans));