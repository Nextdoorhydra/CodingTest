using System.Collections;

class c9093
{
    static void Main(string[] args)
    {

        string input = Console.ReadLine();
        int T = int.Parse(input);
        string[] test = new string[T];

        //단어의 길이는 최대 20, 문장의 길이는 최대 1000, 단어 사이 공백
        for(int i = 0; i < T; i++)
        {
            test[i] = Console.ReadLine();
        }

        for(int idx = 0; idx < T; idx++)
        {
            char[] txt = test[idx].ToCharArray();

            Stack st = new Stack();

            int start = 0;

            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] != ' ')
                {
                    st.Push(txt[i]);
                }
                else //스택 넣기
                {
                    while (start != i)
                    {
                        txt[start++] = (char)st.Pop();
                    }
                    start++;
                }
            }
            //마지막 단어 검출
            if (st.Count != 0)
            {
                while (start != txt.Length)
                {
                    txt[start++] = (char)st.Pop();
                }
            }
            Console.WriteLine(txt);
        }
    }
}