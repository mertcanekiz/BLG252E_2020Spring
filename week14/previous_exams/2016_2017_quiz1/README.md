# Quiz 1

## Question 1

Copy and paste the following code to create the 2D-array required for the program. The information contained in this 2D array can be thought of as error codes. The first is the major value for the error, the second is the minor value. You should ask the user how they want the information to be ordered. And according to that, the values must be sorted and printed. Ordering can be one of

1. Most critical to least critical
2. Least critical to most critical
3. Most frequent to least frequent
4. Least frequent to most frequent

```c#
private static int[,] ArrayInitializer()
{
    return new int[,] {
        { 5, 6 },
        { 1, 2 },
        { 1, 3 },
        { 2, 2 },
        {11, 7 },
        { 5, 3 },
        { 4, 11},
        {15, 8 },
        {14, 2 },
        { 3, 9 },
        { 7, 4 },
        { 6, 8 },
        { 8, 6 },
        { 9, 5 },
        {11, 3 },
        {15, 5 },
        {13, 15},
        {18, 14},
        { 5, 19},
        {15, 16},
        {15, 11},
        {13, 12},
        {14, 5 },
        { 1, 13},
        { 8, 5 },
        { 9, 7 }
    };
}
```

## Question 2

In this question, you will order fines and payment information. You can obtain the list that you are going to use for this question by using the method below. The first dimension will represent fines. Each fine will start with an ID value. The IDs are unique. The second value is the amount paid, and the third value is the total fine. One person may have received more than one fine.

According to this information and the user input, do the following:

1. Order by the number of times a person is fined and print their ID numbers and the number of times they have been fined.
2. Order by the amount of fine and print their ID numbers and the amount of fine they have received.
3. Order by how much debt they have yet to pay, and print how much they owe.
4. Order by ID numbers and print total amount of fines, amount paid, amount remaining, and how many fines they have. For example, `4: 500 370 130 (5 fines)`

```c#
private static int[,] ArrayInitializer() {
    return new int[,] {
        { 1, 10, 10 },
        { 2, 10, 20 },
        { 3, 15, 100 },
        { 4, 250, 300 },
        { 1, 50, 150 },
        { 6, 47, 60 },
        { 7, 50, 150 },
        { 3, 0, 175 },
        { 3, 80, 145 },
        { 8, 0, 250 },
        { 9, 15, 45 },
        { 4, 40, 40 },
        { 6, 8, 15 },
        { 8, 60, 60 },
        { 10, 50, 50 },
        { 11 , 451, 452 },
        { 12, 15, 46 },
        { 13, 45, 55 },
        { 13, 50, 95 },
        { 14, 55, 80 },
        { 10, 20, 50 },
        { 15, 16, 46 },
        { 16, 0, 450 },
        { 17, 10, 100 },
        { 17, 5, 145 },
        { 2, 13, 23 },
        { 8, 95, 235 },
        { 9, 70, 70 }
    };
}
```

## Question 3

For a lottery, 6 numbers are chosen from 1-49. This means that there are (49 choose 6) different options. But if the person playing the lottery has 2 lucky numbers and they play these numbers each time they play the number of choices will be (47 choose 4). Or if they have 3 unlucky numbers and they never play those numbers, the number becomes (46 choose 6).

1. Take maximum and minimum numbers from the user (check that the maximum is greater than minimum).
2. Take how many numbers are to be chosen from the user (If the range is 51-70 there needs to be less than 20 numbers so that there is a chance factor).
3. Print how many possibilities there are.
4. Ask the user how many times they want to play. They cannot play more than the number of possibilities you have found in the previous step.
5. Calculate how many lucky numbers a user can have and print this number to the screen.
6. Tell the user to input their lucky numbers or press enter to continue.
7. If they are able to enter unlucky numbers, tell the user to input unlucky numbers or press enter to continue.
8. Print the tickets to the console.
