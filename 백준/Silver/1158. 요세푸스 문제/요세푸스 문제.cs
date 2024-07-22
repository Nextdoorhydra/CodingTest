using System;
using System.Text;

string[] inputs = Console.ReadLine().Split(" ");
int N = int.Parse(inputs[0]); int K = int.Parse(inputs[1]);

StringBuilder sb = new StringBuilder(); 
Queue<int> queue = new Queue<int>();

for (int i = 0; i < N; i++) queue.Enqueue(i + 1);

sb.Append("<");
while(queue.Count > 1)
{
    for (int i = 1; i < K; i++) queue.Enqueue(queue.Dequeue());
    sb.Append($"{queue.Dequeue()}, ");
}
sb.Append($"{queue.Dequeue()}>"); 

Console.WriteLine(sb);