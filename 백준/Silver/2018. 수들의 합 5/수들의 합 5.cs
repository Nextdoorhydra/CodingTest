int n = int.Parse(Console.ReadLine());

var twoPoint = (int[] arr) =>
{
    int l = 0, r = 0, acc = 0, sum = arr[l];

    while(l <= r)
    {
        if (sum == arr.Length)
        {
            acc++;
            sum -= arr[l++];
        }
        else if (sum < arr.Length)
        {
            sum += arr[++r];
        }
        else
        {
            sum -= arr[l++];
        }
    }

    return acc;
};

Console.WriteLine(twoPoint(Enumerable.Range(1, n).ToArray()));