using System.Text.RegularExpressions;

var matches = Regex.Matches(Console.ReadLine(), @"(\d+)|([+-])");

Func<Match, string> S = s => s.ToString();
Func<Match, int> N = s => int.Parse(S(s));
int result = N(matches[0]);

for (int i = 1; i < matches.Count();)
{
    switch (S(matches[i]))
    {
        case "+":
            result += N(matches[i + 1]);
            i+=2;
            break;
        case "-":
            int sum = 0;

            do
            {
                sum += N(matches[i + 1]);
                i += 2;
            } while (i < matches.Count() && S(matches[i]) == "+");

            result -= sum;
            break;
    }
}

Console.WriteLine(result);