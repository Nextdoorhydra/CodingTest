var ll = new LinkedList<int>(Enumerable.Range(1, int.Parse(Console.ReadLine()!)));

while (ll.Count > 1)
{
    ll.RemoveFirst();
    ll.AddLast(ll.First!.Value);
    ll.RemoveFirst();
}

Console.WriteLine(ll.First!.Value);