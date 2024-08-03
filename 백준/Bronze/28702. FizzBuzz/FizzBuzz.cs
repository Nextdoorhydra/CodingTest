Func<int, string> FizzBuzz = (n) =>
{
    if (n % 15 == 0)
    {
        return "FizzBuzz";
    }
    else if (n % 3 == 0)
    {
        return "Fizz";
    }
    else if (n % 5 == 0)
    {
        return "Buzz";
    }
    else
    {
        return n.ToString();
    }
};

Func<string, bool> IsFizzBuzz = s => s == "Fizz" || s == "Buzz" || s == "FizzBuzz";

var a = Console.ReadLine();
var b = Console.ReadLine();
var c = Console.ReadLine();

if (!IsFizzBuzz(a)) Console.WriteLine(FizzBuzz(int.Parse(a) + 3));
else if (!IsFizzBuzz(b)) Console.WriteLine(FizzBuzz(int.Parse(b) + 2));
else if (!IsFizzBuzz(c)) Console.WriteLine(FizzBuzz(int.Parse(c) + 1));