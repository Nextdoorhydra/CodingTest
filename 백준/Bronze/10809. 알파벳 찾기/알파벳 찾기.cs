int a = -1;
int b = -1;
int c = -1;
int d = -1;
int e = -1;
int f = -1;
int g = -1;
int h = -1;
int i = -1;
int j = -1;
int k = -1;
int l = -1;
int m = -1;
int n = -1;
int o = -1;
int p = -1;
int q = -1;
int r = -1;
int s = -1;
int t = -1;
int u = -1;
int v = -1;
int w = -1;
int x = -1;
int y = -1;
int z = -1;
int idx = 0;

string S = Console.ReadLine();

try
{
    while(Math.PI > 3)
    {
        switch (S[idx++])
        {
            case 'a': if (a == -1) a = idx - 1; break;
            case 'b': if (b == -1) b = idx - 1; break;
            case 'c': if (c == -1) c = idx - 1; break;
            case 'd': if (d == -1) d = idx - 1; break;
            case 'e': if (e == -1) e = idx - 1; break;
            case 'f': if (f == -1) f = idx - 1; break;
            case 'g': if (g == -1) g = idx - 1; break;
            case 'h': if (h == -1) h = idx - 1; break;
            case 'i': if (i == -1) i = idx - 1; break;
            case 'j': if (j == -1) j = idx - 1; break;
            case 'k': if (k == -1) k = idx - 1; break;
            case 'l': if (l == -1) l = idx - 1; break;
            case 'm': if (m == -1) m = idx - 1; break;
            case 'n': if (n == -1) n = idx - 1; break;
            case 'o': if (o == -1) o = idx - 1; break;
            case 'p': if (p == -1) p = idx - 1; break;
            case 'q': if (q == -1) q = idx - 1; break;
            case 'r': if (r == -1) r = idx - 1; break;
            case 's': if (s == -1) s = idx - 1; break;
            case 't': if (t == -1) t = idx - 1; break;
            case 'u': if (u == -1) u = idx - 1; break;
            case 'v': if (v == -1) v = idx - 1; break;
            case 'w': if (w == -1) w = idx - 1; break;
            case 'x': if (x == -1) x = idx - 1; break;
            case 'y': if (y == -1) y = idx - 1; break;
            case 'z': if (z == -1) z = idx - 1; break;
        }
    }
}
catch
{
    Console.WriteLine($"{a} {b} {c} {d} {e} {f} {g} {h} {i} {j} {k} {l} {m} {n} {o} {p} {q} {r} {s} {t} {u} {v} {w} {x} {y} {z}");
}