int n = int.Parse(Console.ReadLine()), ans = 0;
var seq = Console.ReadLine().Split().Select(int.Parse).ToList(); seq.Sort();

for (int i = 0; i < n; i++)
{
    int key = seq[i], sum, l = 0, r = n - 1;

    while (l < r)
    {
        sum = seq[l] + seq[r];

        if (sum > key)
        {
            r--;
        }
        else if (sum < key)
        {
            l++;
        }
        else
        {
            if (l == i)
            {
                l++;
            }
            else if (r == i)
            {
                r--;
            }
            else
            {
                ans++;
                break;
            }
        }
    }
}

Console.WriteLine(ans);