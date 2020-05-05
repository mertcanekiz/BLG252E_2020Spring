# Week 11

# Code Wars Katas

## 7kyu

### [Vowel Count](https://www.codewars.com/kata/54ff3102c1bad923760001f3)

```c#
using System;
using System.Linq;

public static class Kata
{
    public static int GetVowelCount(string str)
    {
        int vowelCount = 0;
        for (int i = 0; i < str.Length; i++) {
            if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' ||
                    str[i] == 'o' || str[i] == 'u') {
                    vowelCount++;
            }
        }
        return vowelCount;
    }
}
```

```c#
using System;
using System.Linq;

public static class Kata
{
    public static int GetVowelCount(string str)
    {
        int vowelCount = 0;
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        for (int i = 0; i < str.Length; i++) {
            if (vowels.Contains(str[i])) {
                vowelCount++;
            }
        }
    }
}
```

```c#
using System;
using System.Linq;

public static class Kata
{
    public static int GetVowelCount(string str)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        int vowelCount = str.Count(c => vowels.Contains(c));
        return vowelCount;
    }
}
```

```c#
using System;
using System.Linq;

public static class Kata
{
    public static int GetVowelCount(string str)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        return str.Count(vowels.Contains);
    }
}
```

### [Highest and Lowest](https://www.codewars.com/kata/554b4ac871d6813a03000035)

```c#
using System;
using System.Collections.Generic;

public static class Kata
{
  public static string HighAndLow(string numbers)
  {
      int highest = 0; // int.MinValue;
      int lowest = 0; // int.MaxValue;
      var ints = new List<int>();
      foreach (string num in numbers.Split(' ')) {
          ints.Add(int.Parse(num));
      }
      foreach (int num in ints) {
          if (num > highest) {
              highest = num;
          }
          if (num < lowest) {
              lowest = num;
          }
      }
      return $"{highest} {lowest}";
  }
}
```

```c#
using System;
using System.Collections.Generic;

public static class Kata
{
  public static string HighAndLow(string numbers)
  {
      int highest = int.MinValue;
      int lowest = int.MaxValue;
      
      foreach (string num in numbers.Split(' ')) {
          int number = int.Parse(num);
          if (number > highest) {
              highest = number;
          }
          if (number < lowest) {
              lowest = number;
          }
      }
      
      return $"{highest} {lowest}";
  }
}
```

```c#
using System;
using System.Collections.Generic;

public static class Kata
{
  public static string HighAndLow(string numbers)
  {
      int highest = int.MinValue;
      int lowest = int.MaxValue;
      int[] ints = Array.ConvertAll(numbers.Split(' '), s => int.Parse(s));
      
      return $"{ints.Max()} {ints.Min()}";
  }
}
```

# 6 kyu

### [Find the odd int](https://www.codewars.com/kata/54da5a58ea159efa38000836)

```c#
using System;
using System.Collections.Generic;

namespace Solution
{
    class Kata
    {
        public static int find_it(int[] seq)
        {
            int result = 0;
            Dictionary<int, int> occurrences = new Dictionary<int, int>();
            foreach (var num in seq) {
                if (occurrences.ContainsKey(num)) {
                    occurrences[num]++;
                } else {
                    occurrences[num] = 1;
                }
            }
            foreach (var pair in occurrences) {
                if (pair.Value % 2 == 1) {
                    result = pair.Key;
                }
            }
            return result;
        }
    }
}
```

```c#
using System;
using System.Collections.Generic;

namespace Solution
{
    class Kata
    {
        public static int find_it(int[] seq)
        {
            return seq.GroupBy(x => x).Single(g => g.Count() % 2 == 1).Key;
        }
    }
}
```

```c#
namespace Solution
{
    class Kata
    {
        public static int find_it(int[] seq)
        {
            int found = 0;
            foreach (var num in seq) {
                found ^= num;
            }
            // seq = { 3, 1, 3, 4, 4 };
            // 0000 ^ 0011 = 0011
            // 0011 ^ 0011 = 0000
            // 0000 ^ 0100 = 0100
            // 0100 ^ 0100 = 0000
            // 0000 ^ 0001 = 0001
            return found;
        }
    }
}
```

### [Detect Pangram](https://www.codewars.com/kata/545cedaa9943f7fe7b000048)

```c#
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata
{
    public static bool IsPangram(string str)
    {
        var alphabetString = "abcdefghijklmnopqrstuvwxyz";
        var alphabet = new HashSet<char>(alphabetString.ToCharArray());
        var set = new HashSet<char>(str.ToLower().ToCharArray());
        return set.IsSupersetOf(alphabet);
    }
}
```

```c#
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata
{
    public static bool IsPangram(string str)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        var foundCharacters = new Dictionary<char, bool>();
        foreach (char c in alphabet) {
            foundCharacters[c] = false;
        }
        foreach (char c in str.ToLower()) {
            foundCharacters[c] = true;
        }
        return foundCharacters.All(pair => pair.Value);
    }
}
```

### [Duplicate Encoder](https://www.codewars.com/kata/54b42f9314d9229fd6000d9c)

```c#
using System.Collections.Generic;

public class Kata
{
    public static string DuplicateEncode(string word)
    {
        var counts = new Dictionary<char, int>();
        foreach (var c in word.ToUpper()) {
            if (counts.ContainsKey(c)) {
                counts[c]++;
            } else {
                counts[c] = 1;
            }
        }
        string result = "";
        foreach (var c in word.ToUpper()) {
            if (counts[c] == 1) {
                result += "(";
            } else {
                result += ")";
            }
        }
        return result;
    }
}
```

```c#
using System.Linq;
public class Kata
{
    public static string DuplicateEncode(string word)
    {
        return new string(word.ToLower().Select(c => word.ToLower().Count(c2 => c == c2) == 1 ? '(' : ')').ToArray());
    }
}
```

### [Array.diff](https://www.codewars.com/kata/523f5d21c841566fde000009)

```c#
using System.Collections.Generic;

public class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        var result = new List<int>();
        for (int i = 0; i < a.Length; i++) {
            bool found = false;
            for (int j = 0; j < b.Length; j++) {
                if (b[j] == a[i]) {
                found = true;
                break;
                }
            }
            if (!found) {
                result.Add(a[i]);
            }
        }
        return result.ToArray();
    }
}
```

LINQ
```c#
using System.Linq;
public class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        return a.Where(i => !b.Contains(i)).ToArray();
    }
}
```

LINQ query syntax
```c#
using System.Linq;
public class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        var cleaned = from i in a
                      where !b.Contains(i)
                      select i;
        return cleaned.ToArray();
    }
}
```

LINQ with HashSet
```c#
using System.Linq;
using System.Collections.Generic;
public class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        var bSet = new HashSet<int>(b);
        return a.Where(i => !b.Contains(i)).ToArray();
    }
}
```

## 5 kyu

### [Directions Reduction](https://www.codewars.com/kata/550f22f4d758534c1100025a)

```c#
using System;
using System.Collections.Generic;
using System.Linq;

public class DirReduction {
    public static string[] dirReduc(string[] arr) {
        var dirList = arr.ToList();
        for (int i = 1; i < dirList.Count; i++) {
            if ((dirList[i] == "SOUTH" && dirList[i-1] == "NORTH") ||
                (dirList[i] == "NORTH" && dirList[i-1] == "SOUTH") ||
                (dirList[i] == "EAST"  && dirList[i-1] == "WEST" ) ||
                (dirList[i] == "WEST"  && dirList[i-1] == "EAST" ))
            {
                dirList.RemoveRange(i - 1, 2);
                i = 0;
            }
        }
        return dirList.ToArray();
    }
}
```

Talk about stacks first, maybe wikipedia?

```c#
using System;
using System.Collections.Generic;
public class DirReduction {
    public static string[] dirReduc(string[] arr) {
        Stack<string> stack = new Stack<string>();
        foreach (string direction in arr) {
            string lastElement = stack.Count > 0 ? stack.Peek().ToString() : null;
            switch (direction) {
                case "NORTH": if (lastElement == "SOUTH") stack.Pop(); else stack.Push(direction); break;
                case "SOUTH": if (lastElement == "NORTH") stack.Pop(); else stack.Push(direction); break;
                case "EAST":  if (lastElement == "WEST") stack.Pop(); else stack.Push(direction); break;
                case "WEST":  if (lastElement == "EAST") stack.Pop(); else stack.Push(direction); break;
            }
        }
        string[] result = stack.ToArray();
        Array.Reverse(result);
        return result;
    }
}
```

```c#
using System.Linq;
using System.Text.RegularExpressions;

public class DirReduction {
    public static string[] dirReduc(string[] arr) {
        string s = new string(arr.Select(x => x[0]).ToArray());
        while (Regex.Match(s, "NS|EW|SN|WE").Success)
            s = Regex.Replace(s, "NS|EW|SN|WE", "");
        return s.Select(x => x == 'N' ? "NORTH": x == 'S' ? "SOUTH" : x == 'E' ? "EAST" : "WEST").ToArray();
    }
}
```

### [Simple Pig Latin](https://www.codewars.com/kata/520b9d2ad5c005041100000f)

```c#
using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static string PigIt(string str)
    {
        var result = "";
        foreach (var word in str.Split(' ')) {
            if (!word.All(char.IsLetterOrDigit)) {
                result += word;
                continue;
            }
            string latin = word.Substring(1) + word[0] + "ay";
            result += latin;
            result += " ";
        }
        return result.Trim();
    }
}
```

```c#
using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static string PigIt(string str)
    {
        var words = new List<string>();
        foreach (var word in str.Split(' ')) {
            if (!word.All(char.IsLetterOrDigit)) {
              words.Add(word);
              continue;
            }
            string latin = word.Substring(1) + word[0] + "ay";
            words.Add(latin);
        }
        return string.Join(" ", words);
    }
}
```

If we don't care about punctuation:
```c#
using System.Linq;

public class Kata
{
    public static string PigIt(string str)
    {
        return string.Join(" ", str.Split(' ').Select(w => {
            if (!w.All(char.IsLetterOrDigit)) {
                return w;
            }
            return w.Substring(1) + w[0] + "ay";
        }));
    }
}
```

### [Weight for weight](https://www.codewars.com/kata/55c6126177c9441a570000cc)

```c#
using System;
using System.Linq;

public class WeightSort {
    public static int digitSum(string num) {
        int result = 0;
        foreach (char c in num) {
            result += c - '0';
        }
        return result;
    }
    public static string orderWeight(string str) {
        string[] weights = str.Split(' ');
        return string.Join(" ", weights.OrderBy(w => digitSum(w)).OrderBy(w => w).ToArray());
    }
}
```

```c#
using System;
using System.Linq;

public class WeightSort {
    public static string orderWeight(string str) {
        string[] weights = str.Split(' ');
        return string.Join(" ", weights.OrderBy(w => w).OrderBy(w => w.Sum(c => c - '0')).ToArray());
    }
}
```

# Project Euler

### [Longest Collatz sequence](https://projecteuler.net/problem=14)

```c#
using System;
using System.Collections.Generic;

namespace longest_collatz_sequence
{
    class Program
    {
        static Dictionary<long, long> previouslyFound = new Dictionary<long, long>();
        static long highestNumber = 0;

        static long Collatz(long n)
        {
            long result = 0;
            long num = n;
            while (n != 1) {
                if (previouslyFound.ContainsKey(n)) {
                    return result + previouslyFound[n] + 1;
                }
                if (n > highestNumber) highestNumber = n;
                if (n % 2 == 0) n /= 2;
                else n = 3 * n + 1;
                result++;
            }
            previouslyFound[num] = result; 
            return result;
        }

        static void Main(string[] args)
        {
            long longest = 0, maxN = 0;
            for (long i = 2; i < 1000000; i++) {
                long current = Collatz(i);
                if (current > longest) {
                    longest = current;
                    maxN = i;
                }
                if (i % 1000 == 0) Console.WriteLine(i);
            }
            Console.WriteLine($"{maxN}: {longest}");
            Console.WriteLine(highestNumber);
        }
    }
}
```