using System;
using System.Collections.Generic;

namespace longest_collatz_sequence
{
    class Program
    {
        static Dictionary<long, long> previouslyFound = new Dictionary<long, long>();
        static long Collatz(long n)
        {
            long result = 0;
            long num = n;
            while (n != 1) {
                if (previouslyFound.ContainsKey(n)) {
                    return result + previouslyFound[n] + 1;
                }
                if (n % 2 == 0) {
                    n /= 2;
                } else {
                    n = 3*n + 1;
                }
                result++;
            }
            previouslyFound[num] = result;
            return result;
        }

        static void Main(string[] args)
        {
            long longestLength = 0, maxN = 0;
            for (int i = 2; i < 1000000; i++) {
                long current = Collatz(i);
                if (current > longestLength) {
                    longestLength = current;
                    maxN = i;
                }
            }
            Console.WriteLine($"{maxN}: {longestLength}");
        }
    }
}
