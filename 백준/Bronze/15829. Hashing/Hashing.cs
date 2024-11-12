Console.ReadLine();
Console.WriteLine(Console.ReadLine().ToCharArray()
    .Select((x, i) => (x - 'a' + 1) * Enumerable.Repeat(31, i)
    .Aggregate(1L, (pre, x) => (pre * x) % 1234567891)).Sum() % 1234567891);