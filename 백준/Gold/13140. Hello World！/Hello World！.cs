using System;

int[] table = new int[7];
int result = int.Parse(Console.ReadLine());

if (result > 184010 || result < 33986) goto OUT; //종료

if (recur(0, 0)) 
{
    Console.WriteLine($"  {table[(int)ch.h]}{table[(int)ch.e]}{table[(int)ch.l]}{table[(int)ch.l]}{table[(int)ch.o]}\n" +
                      $"+ {table[(int)ch.w]}{table[(int)ch.o]}{table[(int)ch.r]}{table[(int)ch.l]}{table[(int)ch.d]}\n" +
                      "-------\n" +
                      ((result > 99999) ? " " : "  ") + result); return;
}

OUT: Console.WriteLine("No Answer"); return;

bool recur(int len, int check)
{
    if(len == 7)
    {
        int sum1 = table[(int)ch.h] * 10000 + table[(int)ch.e] * 1000 + table[(int)ch.l] * 100 + table[(int)ch.l] * 10 + table[(int)ch.o];
        int sum2 = table[(int)ch.w] * 10000 + table[(int)ch.o] * 1000 + table[(int)ch.r] * 100 + table[(int)ch.l] * 10 + table[(int)ch.d];
        
        if (sum1 + sum2 == result) return true; return false;
    }
    int i = (len != (int)ch.h && len != (int)ch.w) ? 0 : 1;
    for (; i < 10; i++)
    {
        if ((check & 1 << i) > 0) continue; 
        table[len] = i;
        if (recur(len + 1, check | 1 << i)) return true;
    }
    return false;
}

enum ch { h = 0, e, l, o, w, r, d }