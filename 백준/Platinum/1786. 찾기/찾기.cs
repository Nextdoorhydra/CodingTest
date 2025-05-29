string text = Console.ReadLine(), pat = Console.ReadLine();
var kmpTable = new int[pat.Length];
var A = new List<int>();

kmpTable[0] = -1;
int i = 1, j = -1;

for (; i < pat.Length; i++)
{
    while (j >= 0 && pat[i] != pat[j + 1])
        j = kmpTable[j];

    if (pat[i] == pat[j + 1])
        j++;

    kmpTable[i] = j;
}

for (i = 0, j = -1; i < text.Length; i++)
{
    while (j >= 0 && text[i] != pat[j + 1])
        j = kmpTable[j];

    if (text[i] == pat[j + 1])
        j++;

    if (j == pat.Length - 1)
    {
        A.Add(i - j + 1);
        j = kmpTable[j];
    }
}

Console.WriteLine($"{A.Count}\n{String.Join(' ', A)}");