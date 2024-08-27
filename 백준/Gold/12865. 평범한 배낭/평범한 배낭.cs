var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var ls = new List<(int weight, int value)>();
var table = new int[input[0], input[1] + 1]; //v, w

for (int i = 0; i < input[0]; i++)
{
    var _input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    ls.Add((_input[0], _input[1]));
}

Console.WriteLine(recur(input[0], input[1]));

int recur(int count, int weight)
{
    if(count == 0 || weight < 0) return 0;

    if (table[count - 1, weight] == 0)
    {
        int TryWeight = weight - ls[count - 1].weight;
        int a = recur(count - 1, TryWeight) + (TryWeight >= 0 ? ls[count - 1].value : 0);
        int b = recur(count - 1, weight);

        table[count - 1, weight] = Math.Max(a, b);
    }

    return table[count - 1, weight];
}