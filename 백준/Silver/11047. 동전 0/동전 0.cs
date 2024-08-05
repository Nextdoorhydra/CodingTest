var In = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var g = new int[In[0]];
for(int i = 0; i < In[0]; i++) g[i] = int.Parse(Console.ReadLine());

int ans = 0;

for(int i = In[0] - 1; i >= 0; i--)
{
    ans += In[1] / g[i];
    In[1] %= g[i];
}

Console.WriteLine(ans);