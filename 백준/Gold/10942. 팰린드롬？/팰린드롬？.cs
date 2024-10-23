using StreamWriter sw = new(Console.OpenStandardOutput());
var read = () => Console.ReadLine().Split().Select(int.Parse).ToArray();

int S, E, N, M, ANS = 0;
N = read()[0];
var seq = read();
M = read()[0];
Dictionary<double, (int a, int b)> PL = new(), NPL = new();
var getAxis = (int a, int b) => (a + b) * 0.5;

for (int i = 0; i < M; i++)
{
    var input = read();
    S = --input[0]; E = --input[1];

    var axis = getAxis(S, E);

    if (PL.ContainsKey(axis) && PL[axis].a <= S && PL[axis].b >= E)
    {
        ANS = 1;
    }
    else if (NPL.ContainsKey(axis) && NPL[axis].a >= S && NPL[axis].b <= E)
    {
        ANS = 0;
    }
    else if (isPalindrome(S, E))
    {
        if (!PL.TryAdd(axis, (S, E)))
            PL[axis] = (S, E);
        ANS = 1;
    }
    else
    {
        if (!NPL.TryAdd(axis, (S, E)))
            NPL[axis] = (S, E);
        ANS = 0;
    }

    sw.WriteLine(ANS);
}

bool isPalindrome(int s, int e)
{
    var axis = getAxis(s, e);
    while (s <= e)
    {

        if (PL.ContainsKey(axis) && PL[axis].a <= s && PL[axis].b >= e)
            return true;
        else if ((NPL.ContainsKey(axis) && NPL[axis].a >= s && NPL[axis].b <= e) || seq[s++] != seq[e--])
            return false;
    }
    return true;
}