using System.Collections;

class c17413
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        char[] txt = input.ToCharArray();

        Stack st = new Stack();

        int start = 0;

        while(start < txt.Length)
        {
            //뒤집기
            for (int i = start; i < txt.Length && txt[i] != ' ' && txt[i] != '<'; i++)
            {
                st.Push(txt[i]);
            }
            //뒤집은거 넣기
            while(st.Count > 0)
            {
                txt[start++] = (char)st.Pop();
            }
            //태그 검열
            while (start < txt.Length && txt[start] == '<')
            {
                while (start < txt.Length && txt[start] != '>')
                {
                    start++;
                }
            }
            start++;
        }
        Console.WriteLine(txt);
    }
}