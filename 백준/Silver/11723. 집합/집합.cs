using System.Text;

int S = 0;
StringBuilder sb = new StringBuilder();

int n = int.Parse(Console.ReadLine());

for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();
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
            sb.Append((((S & (1 << x)) == 0 ? 0 : 1)) + "\n");
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

Console.WriteLine(sb);