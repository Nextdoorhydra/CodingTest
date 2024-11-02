using StreamWriter sw = new(Console.OpenStandardOutput());

while(true)
{
    var input = Console.ReadLine();
    if (input == ".") return;

    var str = new string(input.ToCharArray().Where(c => c == '(' || c == '[' || c == ')' || c == ']').ToArray());
    sw.WriteLine(isValid(str) ? "yes" : "no");
}

bool isValid(string str)
{
    for (int i = 0; i <= 50; i++)
    {
        str = str.Replace("[]", "");
        str = str.Replace("()", "");
    }
    return str.Length == 0;
}