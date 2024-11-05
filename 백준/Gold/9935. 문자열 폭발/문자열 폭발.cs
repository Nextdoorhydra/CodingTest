using System.Text;

string str = Console.ReadLine(), TNT = Console.ReadLine();
int tntLength = TNT.Length;
StringBuilder sb = new();

foreach (char c in str)
{
    sb.Append(c);

    if (sb.Length >= tntLength &&
        sb.ToString(sb.Length - tntLength, tntLength) == TNT)
        sb.Length -= tntLength;
}

Console.WriteLine(sb.Length == 0 ? "FRULA" : sb.ToString());