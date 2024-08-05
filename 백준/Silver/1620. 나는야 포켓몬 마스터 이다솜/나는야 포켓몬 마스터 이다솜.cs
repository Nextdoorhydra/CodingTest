using System.Text;

StreamReader sb = new(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

Dictionary<int, string> IdDic = new Dictionary<int, string>();
Dictionary<string, int> NameDic = new Dictionary<string, int>();

var input = Array.ConvertAll(sb.ReadLine().Split(), int.Parse);
for (int i = 0; i < input[0]; i++)
{
    string s = sb.ReadLine();
    IdDic.Add(i + 1, s);
    NameDic.Add(s, i + 1);
}

for(int i = 0; i < input[1]; i++)
{
    int id; string name;

    if (int.TryParse(name = sb.ReadLine(), out id))
    {
        sw.WriteLine(IdDic[id]);
    }
    else
    {
        sw.WriteLine(NameDic[name]);
    }
}

sb.Close();
sw.Close();