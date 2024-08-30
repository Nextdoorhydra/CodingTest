using StreamWriter sw = new(Console.OpenStandardOutput());
int count = int.Parse(Console.ReadLine()), max = GetMax(count);

dfs(0, 0);

void dfs(int depth, int number)
{
    if (depth == count)
    {
        sw.WriteLine(number);
        return;
    }

    for(int i = 1; i <= 9; i++)
    {
        int next = number * 10 + i;
        if(IsPrime(next)) dfs(depth + 1, number * 10 + i);
    }
}

bool IsPrime(int x)
{
    if (x is 1 or < 1) return false;
    if (x is 2) return true;
    if (x % 2 is 0) return false;

    var max = (int)Math.Floor(Math.Sqrt(x));
    
    for(int i = 3; i < x; i += 2)
    {
        if(x % i is 0)
            return false;
    }

    return true;
}

int GetMax(int target)
{
    int acc = 1;
    for(int i = 0; i < target; i++)
    {
        acc = acc * 10;
    }
    return acc;
}