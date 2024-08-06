using System.Text;

StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

Func<(int, int), (int, int), (int, int)> Plus = (x, y)  => (x.Item1 + y.Item1, x.Item2 + y.Item2);
Func<(int, int), string> TupleToString = x => $"{x.Item1} {x.Item2}";

var memo = new (int zero, int one)[41];
memo[0].zero++; memo[1].one++;

int size = int.Parse(sr.ReadLine());

for(int i  = 0; i < size; i++) sw.WriteLine(TupleToString(fibonacci(int.Parse(sr.ReadLine()))));

(int, int) fibonacci(int n)
{

    if (n < 0) return (0, 0);
    if (memo[n] != (0, 0)) return memo[n];
    memo[n] = Plus(fibonacci(n - 1), fibonacci(n - 2));
    return memo[n];
}

sr.Close();
sw.Close();