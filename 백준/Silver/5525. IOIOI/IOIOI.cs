var read = () => Console.ReadLine();
int N = int.Parse(read()), M = int.Parse(read());
var str = read();
var pattern = new string(Enumerable.Range(1, 2 * N + 1).Select(x => x % 2 != 0 ? 'I' : 'O').ToArray());

int ANS = 0;

for(int i = 0; i <= M - pattern.Length; i++)
{
    if (match(str, pattern, i))
    {
        i++;
        ANS++;
    }
}

Console.WriteLine(ANS);

bool match(string s, string p, int idx)
{
    bool flag = true;

    for(int i = 0; i < p.Length; i++)
    {
        if (s[idx + i] != p[i])
        {
            flag = false;
            break;
        }
    }

    return flag;
}