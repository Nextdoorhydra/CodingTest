using System.Text;

int S = 0;
StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int n = int.Parse(sr.ReadLine());

for(int i = 0; i < n; i++)
{
    Span<string> input = sr.ReadLine().Split();
    int x = input.Length > 1 ? int.Parse(input[1]) : 0;

    switch (input[0])
    {
        case "add":
            S |= 1 << x;
            break;

        case "remove":
            S &= ~(1 << x);
            break;

        case "check":
            sw.WriteLine((S & (1 << x)) == 0 ? "0" : "1");
            break;

        case "toggle":
            S ^= 1 << x;
            break;

        case "all":
            S = -1;
            break;

        case "empty":
            S = 0;
            break;
    }
}

sr.Close();
sw.Close();