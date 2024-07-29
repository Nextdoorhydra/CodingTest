using System.Text;

StringBuilder sb = new StringBuilder();

int n = int.Parse(Console.ReadLine());

for(int i = 0; i < n; i++)
{
    var condi = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    int H = condi[2];
    int W = 0;

    while(H > condi[0])
    {
        H -= condi[0];
        W++;
    }
    sb.Append($"{H}{(++W < 10 ? "0" : "")}{W}\n");
}

Console.WriteLine(sb);