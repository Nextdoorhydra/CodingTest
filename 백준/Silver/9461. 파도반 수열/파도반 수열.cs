int n = int.Parse(Console.ReadLine());

var memo = new List<long> { 1, 1, 1, 2, 2 };

for (int i = 5; i < 100; i++) memo.Add(memo[i - 5] + memo[i - 1]);

while (n-- > 0) Console.WriteLine(memo[int.Parse(Console.ReadLine()) - 1]);