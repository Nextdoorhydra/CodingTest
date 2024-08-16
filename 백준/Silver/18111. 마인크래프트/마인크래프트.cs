var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int block = input[2];
var g = new int[input[0] * input[1]];
var level = new int[257];

for (int i = 0; i < input[0]; i++)
{
    var _input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    foreach (int x in _input) level[x]++;
}

int l = 0, r = 256, time = 0;

while(l < r)
{
    if (level[l] == 0)
    {
        l++;
    }
    else if(level[r] == 0)
    {
        r--;
    }
    else
    {
        int dig = level[r], fill = level[l];

        if (block < fill || fill > 2 * dig)
        {
            time += 2 * dig;
            block += dig;
            level[r-- - 1] += dig;
        }
        else
        {
            time += fill;
            block -= fill;
            level[l++ + 1] += fill;
        }
    }
}

Console.WriteLine(time + " " + r);