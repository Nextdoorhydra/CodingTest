int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

int m = arr[1] - 45;

if(m >= 0) Console.WriteLine($"{arr[0]} {m}");
else if(--arr[0] >= 0) Console.WriteLine($"{arr[0]} {m + 60}");
else Console.WriteLine($"{arr[0] + 24} {m + 60}");