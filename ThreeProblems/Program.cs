/*
 * Name:        Jonathan Mann
 * Course:      CSCI 1250, Section 002
 * Assignment:  Lab 06, Three Short Problems
 * Date:        October 25, 2026
 * Description: A menu that keeps running until the user quits, offering three
 *              independent exercises or all three at once. Each exercise
 *              practices decisions and one of the four loops.
 */

using System.Runtime.CompilerServices;

int choice = 0;
string letter;
string again;
Random rng = new Random(4000);

do
{
    System.Console.WriteLine("=== CSCI 1250 Lab 06 ===");
    System.Console.WriteLine("1. The Grade Checker");
    System.Console.WriteLine("2. The Dice Table");
    System.Console.WriteLine("3. The Score Report");
    System.Console.WriteLine("4. All Three");
    System.Console.WriteLine("5. Quit");

    System.Console.Write("Choose 1 through 5: ");
    choice = Convert.ToInt32(Console.ReadLine());
    
    if(choice == 1 || choice == 4)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("=== Exercise 1: The Grade Checker ===");

        int score = -1;

        //While loop: the number of bad scores is unknown before the loop starts
        while(score < 0 || score > 100)
        {
            System.Console.Write("Score: ");
            score = Convert.ToInt32(Console.ReadLine());
            if(score < 0 || score > 100)
            {
                System.Console.WriteLine("A score must be between 0 and 100.");
            }
        }

        //if / else if chain that goes from high to low grades
        if(score >= 90)
        {
            letter = "A";
        }
        else if(score >= 80)
        {
            letter = "B";
        }
        else if(score >= 70)
        {
            letter = "C";
        }
        else if(score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        System.Console.WriteLine($"{score} earns a {letter}");
    }


    if(choice == 2 || choice == 4)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("=== Exercise 2: The Dice Table ===");
        int rollCount = 0;
        int winCount = 0;
        // Do while loop to repeat the dice rolling as long as the user inputs "y"
        do
        {
            rollCount++;
            int die1 = rng.Next(1, 7);
            int die2 = rng.Next(1, 7);
            int total = die1 + die2;
            
            System.Console.Write($"Roll {rollCount}: {die1} and {die2}, total {total}. ");
            // else if Chain to 
            if(die1 == 1 && die2 == 1)
            {
                System.Console.Write("Snake eyes.");
            }

            else if(die1 == die2)
            {
                System.Console.Write("Doubles!");
            }

            else if(total == 7 || total == 11)
            {
                System.Console.Write("A winner.");
                winCount++;
            }

            System.Console.WriteLine();

            System.Console.Write("Roll again? (y/n): ");
            again = Console.ReadLine().ToLower();
        }while(again == "y");
    }

    if(choice == 3 || choice == 4)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("=== Exercise 3: The Score Report ===");

        const int NUMBER_OF_SCORES = 5;
        const int PASSING_SCORE = 60;

        int[] scores = new int[NUMBER_OF_SCORES];

        // for loop because it needs a
        for (int i = 0; i < scores.Length; i++)
        {
            Console.Write($"Score {i + 1}: ");
            scores[i] = Convert.ToInt32(Console.ReadLine());
        }

        int total = 0;
        int highest = scores[0];
        int passing = 0;

        // foreach loop because it needs every value
        foreach (int score in scores)
        {
            total += score;

            if (score > highest)
            {
                highest = score;
            }

            if (score >= PASSING_SCORE)
            {
                passing++;
            }
        }

        double average = (double)total / scores.Length;

        Console.WriteLine();
        Console.WriteLine($"Scores entered: {scores.Length}");
        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Average: {average:F1}");
        Console.WriteLine($"Highest: {highest}");
        Console.WriteLine($"Passing: {passing} of {scores.Length}");
    }
} while (choice != 5);

System.Console.WriteLine("Goodbye.");