using System.Collections;

class c5597
{
    static void Main(string[] args)
    {
        int[] st = new int[30];
        for (int i = 0; i < 28; i++)
        {
            string input = Console.ReadLine();
            st[int.Parse(input) - 1] = 1;
        }
        for (int i = 0;i < st.Length; i++)
        {
            if (st[i] == 0)
                Console.WriteLine(i+1);
        }
    }
}