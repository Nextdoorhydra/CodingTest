using System.Collections;

class c9012
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int T = int.Parse(input);
        string[] test = new string[T];

        for (int i = 0; i < T; i++)
        {
            test[i] = Console.ReadLine();
        }

        for (int i = 0; i < T; i++)
        {
            char[] txt = test[i].ToCharArray();
            bool result = false;

            bool flag = false;
            int idx = 0;
            int Lcount = 0; int Rcount = 0;
            while (idx != txt.Length)
            {
                if (txt[idx] == '(')
                {
                    result = false;
                    Lcount++;
                }
                else if (txt[idx] == ')')
                {
                    Rcount++;
                    if(Rcount > Lcount)
                    {
                        result = false; break;
                    }
                    else if (Lcount == Rcount)
                    {
                        result = true;
                    }
                }

                idx++;
            }
            Console.WriteLine(result ? "YES" : "NO");
        }
    }
}