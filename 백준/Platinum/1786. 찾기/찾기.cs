string text = Console.ReadLine(), pattern = Console.ReadLine();
var kmpTable = new int[pattern.Length];
var answer = new List<int>();

var kmp = (string t, string p, ICollection<int> indexContainer) =>
{
    var GetkmpTable = (string s) =>
    {
        var table = new int[s.Length];

        table[0] = -1;
        int i = 1, j = -1;

        for(; i < s.Length; i++)
        {
            while (j >= 0 && s[i] != s[j + 1])
                j = table[j];

            if (s[i] == s[j + 1])
                j++;

            table[i] = j;
        }

        return table;
    };

    var kmpTable = GetkmpTable(pattern);
    int i = 0, j = -1;

    for (; i < t.Length; i++)
    {
        while (j >= 0 && t[i] != p[j + 1])
            j = kmpTable[j];

        if (t[i] == p[j + 1])
            j++;

        if (j == p.Length - 1)
        {
            indexContainer.Add(i - j + 1);
            j = kmpTable[j];
        }
    }
};

kmp(text, pattern, answer);
Console.WriteLine($"{answer.Count}\n{String.Join(' ', answer)}");