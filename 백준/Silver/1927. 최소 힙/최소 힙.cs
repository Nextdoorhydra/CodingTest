using System.Text;

StringBuilder sb = new StringBuilder();
PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int k = int.Parse(Console.ReadLine());
    if(k == 0)
    {
        if(pq.Count > 0)
        {
            sb.AppendLine(pq.Dequeue().ToString());
        }
        else
        {
            sb.AppendLine("0");
        }
    }
    else
    {
        pq.Enqueue(k, k);
    }
}

Console.WriteLine(sb);