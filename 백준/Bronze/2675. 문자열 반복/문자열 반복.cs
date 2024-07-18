using System;
class c2675
{
    static void Main(string[] args)
    {
        int NumberofCase = int.Parse(Console.ReadLine());
        int[] repeat = new int[NumberofCase];
        string[] sentence = new string[NumberofCase];

        for (int i = 0; i < NumberofCase;  i++)
        {
            // 사용자로부터 입력 받기
            string[] inputs = Console.ReadLine().Split(' ');
            // 문자열 배열의 각 요소를 정수로 변환
            repeat[i] = int.Parse(inputs[0]);
            sentence[i] = inputs[1];
        }

        for (int i = 0; i < NumberofCase; i++)
        {
            string _sentence = sentence[i];

            for(int j = 0; j < _sentence.Length; j++)
            {
                for(int k = 0; k < repeat[i]; k++) Console.Write(_sentence[j]);
            }
            Console.WriteLine();
        }
    }
}