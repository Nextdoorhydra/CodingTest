var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

Console.WriteLine(input.SequenceEqual(Enumerable.Range(1, 8).ToArray()) ? "ascending" : 
    input.SequenceEqual(Enumerable.Range(1, 8).Reverse().ToArray()) ? "descending" : "mixed");