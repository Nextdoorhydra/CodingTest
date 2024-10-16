var read = () => Console.ReadLine().Split().Select(int.Parse).ToList();
int k = read()[1];
Console.WriteLine(string.Join(" ", read().Where(x => x < k)));