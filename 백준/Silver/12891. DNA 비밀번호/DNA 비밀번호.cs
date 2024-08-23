var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var str = Console.ReadLine();
var ACGT = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

var cnt = new int[4];
int l = 0, r = input[1], answer = 0;

var getCount = (string str, int n) =>
{
    foreach(var c in str)
    {
        cnt[c switch { 'A' => 0, 'C' => 1, 'G' => 2, _ => 3 }] += n;
    }
};

var IsValid = (int[] arr) => ACGT.Zip(arr, (a, b) => a > b).Count(x => x == true) == 0;

getCount(str[l..r], 1);
if (IsValid(cnt)) answer++;

while(r < input[0])
{
    getCount(str[l++].ToString(), -1);
    getCount(str[r++].ToString(), 1);
    if (IsValid(cnt)) answer++;
}

Console.WriteLine(answer);