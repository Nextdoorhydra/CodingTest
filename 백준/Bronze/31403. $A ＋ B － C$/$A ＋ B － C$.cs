int a = int.Parse(Console.ReadLine());
string b = Console.ReadLine();
int c = int.Parse(Console.ReadLine());
Console.WriteLine($"{a + int.Parse(b) - c}\n{a * Math.Pow(10, b.Length) + int.Parse(b) - c}");