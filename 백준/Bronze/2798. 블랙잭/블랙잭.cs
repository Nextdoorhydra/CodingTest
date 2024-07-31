var condi = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

var groups = from n1 in arr
            from n2 in arr
            from n3 in arr
            where n1 != n2 && n2 != n3 && n3 != n1 && n1 + n2 + n3 <= condi[1]
            select n1 + n2 + n3;

Console.WriteLine(groups.Max());