# Quiz 1

## Question 1: Name Scores
Using [names.txt](./names.txt), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

Write a program that prints the *total* of all the name scores in the file.

## Question 2: Number of Steps to Reduce a Number to Zero

Read the numbers in [nums.txt](./nums.txt), and given a non-negative integer `num`, return the number of steps to reduce it to zero. If the current number is even, you have to divide it by 2, otherwise, you have to subtract 1 from it. If the number is negative or invalid, or the line is empty, return -1. Finally, write all the results to a file called `output.txt`.

### Example 1:
```
Input: 14
Output: 6
```
Explanation:

1) 14 is even; divide by 2 and obtain 7. 
2) 7 is odd; subtract 1 and obtain 6.
3) 6 is even; divide by 2 and obtain 3. 
4) 3 is odd; subtract 1 and obtain 2. 
5) 2 is even; divide by 2 and obtain 1. 
6) 1 is odd; subtract 1 and obtain 0.

### Example 2:
```
Input: 8
Output: 4
```
Explanation: 
1) 8 is even; divide by 2 and obtain 4. 
2) 4 is even; divide by 2 and obtain 2. 
3) 2 is even; divide by 2 and obtain 1. 
4) 1 is odd; subtract 1 and obtain 0.

### Example Input File
```
14
-10

8
abc
```

### Example Output File
```
6
-1
-1
4
-1
```
