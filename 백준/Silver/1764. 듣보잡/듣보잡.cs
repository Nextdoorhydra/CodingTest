List<string> list1 = new List<string>(), list2 = new List<string>();

var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
for (int i = 0; i < input[0]; i++) list1.Add(Console.ReadLine());
for (int i = 0; i < input[1]; i++) list2.Add(Console.ReadLine());

var result = from name1 in list1
             join name2 in list2
             on name1 equals name2
             orderby name1
             select new { name1 };

Console.WriteLine($"{result.Count()}\n{string.Join("\n", result.Select(s => s.name1))}");