using System.Linq;
using System.Text;

StringBuilder sb = new StringBuilder();

int N = int.Parse(Console.ReadLine());

for(int i = 0; i < N; i++)
{
    var input = Console.ReadLine();
    sb.Append(GetGroups(input).Where(x => x != "X")
                      .Select(group => foo(group.Length))
                      .ToArray()
                      .Sum()
                      .ToString() + '\n');
}

Console.Write(sb);

int foo(int x)
{
    if (x == 0) return 0;
    return x + foo(x - 1);
}
IEnumerable<string> GetGroups(string input)
{
    if (string.IsNullOrEmpty(input)) yield break;
    var currentChar = input[0];
    var currentGroup = new List<char> { currentChar };

    for (int i = 1; i < input.Length; i++)
    {
        if (input[i] != 'X' && currentGroup.Contains(input[i])) currentGroup.Add(input[i]);
        else
        {
            yield return new string(currentGroup.ToArray());
            currentChar = input[i];
            currentGroup = new List<char> { currentChar };
        }
    }
    yield return new string(currentGroup.ToArray());
}