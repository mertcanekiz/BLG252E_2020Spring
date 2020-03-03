using System;
using System.Collections.Generic;
using System.Linq;

namespace Week4_Example_Primes
{
    class Program
    {
        static Dictionary<int, int> PrimeFactors(int n)
        {
            // A place to store the final result
            Dictionary<int, int> factors = new Dictionary<int, int>();
            
            // We only need to check up to sqrt(n), because maths
            int limit = (int)Math.Sqrt(n) + 1;
            
            // Start from 2 and check all numbers up to that limit
            for (int i = 2; i < limit; i++) {
                // While n is divisible by a potential factor
                while (n % i == 0) {
                    // Keep dividing n by that factor
                    n /= i;
                    // If that factor exists, increment it, otherwise set it to 1
                    if (factors.ContainsKey(i)) {
                        factors[i]++;
                    } else {
                        factors[i] = 1;
                    }
                }
            }

            // The case where n is a prime number itself
            if (n > 2) factors[n] = 1;
            return factors;
        }

        static void PrintFactors(int n)
        {
            Console.Write($"{n} = ");
            foreach (var pair in PrimeFactors(n))
            {
                Console.Write($"{pair.Key}^{pair.Value}  ");
            }
            Console.WriteLine();
            // Console.WriteLine($"{n} = {string.Join(" * ", PrimeFactors(n).Select(kv => $"{kv.Key}^{kv.Value}").ToArray())}");
        }

        static void Main(string[] args)
        {
            PrintFactors(7);
            PrintFactors(12);
            PrintFactors(100);
            PrintFactors(2*2 * 3 * 5*5 * 7);
        }
    }
}
