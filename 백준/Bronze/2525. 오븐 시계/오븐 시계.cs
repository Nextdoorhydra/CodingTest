var input = Console.ReadLine().Split().Select(int.Parse).ToList();
int m = int.Parse(Console.ReadLine()) + input[1];
Console.WriteLine($"{(input[0] + (m / 60)) % 24} {(m % 60)}");