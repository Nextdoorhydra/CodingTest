var read = () => int.Parse(Console.ReadLine());
int rep = read();

while(rep-- > 0)
{
    int n = read();
    List<string> s = new();
    Console.Write($"Pairs for {n}: ");

    for(int i = 1;; i++)
    {
        if(n > 2 * i)
        {
            s.Add($"{i} {n - i}");
        }
        else
        {
            break;
        }
    }
    Console.WriteLine(string.Join(", ", s));
}