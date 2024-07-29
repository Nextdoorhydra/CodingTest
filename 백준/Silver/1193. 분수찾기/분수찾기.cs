int n = int.Parse(Console.ReadLine()), cnt = 1;

while(n - cnt > 0) n -= cnt++; n--;

int[] forward = Enumerable.Range(1, cnt).ToArray();
int[] reverse = (int[])forward.Clone(); Array.Reverse(reverse);

if(cnt % 2 == 0)
{
    Console.WriteLine($"{forward[n]}/{reverse[n]}");
}
else
{
    Console.WriteLine($"{reverse[n]}/{forward[n]}");
}