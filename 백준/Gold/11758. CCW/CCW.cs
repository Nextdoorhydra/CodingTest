var read = () => Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
int[] p1 = read(), p2 = read(), p3 = read();

var ccw = p1[0] * p2[1] + p2[0] * p3[1] + p3[0] * p1[1] - p1[1] * p2[0] - p2[1] * p3[0] - p3[1] * p1[0];

Console.WriteLine(ccw > 0 ? 1 : ccw < 0 ? -1 : 0);