var read = () => Console.ReadLine();
int N = int.Parse(read()), M = int.Parse(read());
var str = read();
var pattern = new string(Enumerable.Range(1, 2 * N + 1).Select(x => x % 2 != 0 ? 'I' : 'O').ToArray());
var pos = Enumerable.Range(1, pattern.Length).Select(x => x % 2 != 0 ? 0 : 1).ToList();

int ANS = 0, idx = 0;

for(int i = 0; i < M; i++)
{
    if (str[i] == pattern[idx])
    {
        idx++;

        if(idx == pattern.Length)
        {
            ANS++;
            idx -= 2;
        }
    }
    else
    {
        idx = pos[idx];
    }
}

Console.WriteLine(ANS);