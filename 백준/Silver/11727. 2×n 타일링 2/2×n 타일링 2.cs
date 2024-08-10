var M = new int[1001];
M[1] = 1; M[2] = 3;
for (int i = 3; i < M.Length; i++) M[i] = (M[i - 1] + 2 * M[i - 2]) % 10007;
Console.WriteLine(M[int.Parse(Console.ReadLine())]);