using System.Collections;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

class c1874
{
    static void Main(string[] args)
    {
        // +, - 출력용
        StringBuilder sb = new StringBuilder();

        string input = Console.ReadLine();
        int T = int.Parse(input);
        int[] test = new int[T];

        for (int i = 0; i < T; i++)
        {
            string number = Console.ReadLine();
            test[i] = int.Parse(number);
        }

        int stNum = 0;
        Stack st = new Stack();
        Queue log = new Queue();

        for (int idx = 0; idx < T; idx++)
        {
            if(stNum < test[idx])
            {
                //해당 숫자가 나올 때까지 넣기
                do
                {
                    st.Push(++stNum);
                    sb.AppendLine("+");
                } 
                while (stNum != test[idx]);
            }

            //빼기
            if (test[idx] == (int)st.Pop())
            {
                sb.AppendLine("-");
            }
            else
            {
                Console.WriteLine("NO");
                return;
            }
        }
        Console.WriteLine(sb.ToString());
    }
}