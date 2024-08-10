StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var g = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

var memo = new int[input[0] + 1];
memo[0] = 0;

for(int i = 1;  i < memo.Length; i++) memo[i] = g[i - 1] + memo[i - 1];

while (input[1]-- > 0)
{
    var i = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    sw.WriteLine(memo[i[1]] - memo[i[0] - 1]);
}

sr.Close(); 
sw.Close();