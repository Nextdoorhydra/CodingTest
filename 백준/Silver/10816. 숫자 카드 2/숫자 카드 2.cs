int size1 = int.Parse(Console.ReadLine());
var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int size2 = int.Parse(Console.ReadLine());
var arr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int[] ans = new int[size2];
var number = new int[20000001];

Func<int, int> In = x => x >= 0 ? x : 10000000 - x;

for (int i = 0; i < size1; i++) number[In(arr[i])]++;
for (int i = 0; i < size2; i++) ans[i] = number[In(arr2[i])];

Console.WriteLine(string.Join(" ", ans));