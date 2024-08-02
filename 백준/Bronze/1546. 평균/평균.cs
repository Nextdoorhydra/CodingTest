int n = int.Parse(Console.ReadLine());
var arr = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);

Console.WriteLine(arr.Sum(x => x / arr.Max() * 100) / n);