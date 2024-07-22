using System.Numerics;

int N = int.Parse(Console.ReadLine());
BigInteger[] arr = new BigInteger[N + 1]; 

arr[0] = 1;
for(int i = 1; i < N + 1; i++) arr[i] = arr[i - 1] * i; 

string str = arr[N].ToString();

for (int i = str.Length - 1; i >= 0; i--) if (str[i] == '0') arr[0]++; else break;

Console.WriteLine(arr[0] - 1);