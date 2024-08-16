using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
Heap h = new Heap();

while (n-- > 0)
{
    int k = int.Parse(Console.ReadLine());

    if(k == 0)
    {
        sb.AppendLine(h.Delete().ToString());
    }
    else
    {
        h.insert(k);
    }
}

Console.WriteLine(sb);

public class Heap
{
    int[] heap = new int[100_001];
    int size = 1;

    public int Delete()
    {
        if (size == 1) return 0;

        int data = heap[1];
        int temp = heap[--size];
        int parent = 1, child = 2;

        while (child <= size)
        {
            if (child < size && heap[child] < heap[child + 1]) child++;
            if (temp >= heap[child]) break;

            heap[parent] = heap[child];
            parent = child;
            child *= 2;
        }
        heap[parent] = temp;
        return data;
    }

    public void insert(int data)
    {
        int i = size++;

        while (i > 1 && data > heap[i / 2])
        {
            heap[i] = heap[i / 2];
            i /= 2;
        }
        heap[i] = data;
    }
}