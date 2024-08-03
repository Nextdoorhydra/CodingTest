int n = int.Parse(Console.ReadLine());
Stack<int> st = new Stack<int>();

for(int i = 0; i < n; i++)
{
    int k = int.Parse(Console.ReadLine());

    if (k == 0) st.Pop();
    else st.Push(k);
}

Console.WriteLine(st.ToArray().Sum());