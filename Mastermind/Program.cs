//Checks if each number in the guess string is in the range 1 to 6
bool CheckIfInRange(string guess)
{
    int ConvertedNum;

    foreach(char num in guess)
    {
        ConvertedNum = int.Parse(num.ToString());
        if( ConvertedNum < 1 || ConvertedNum > 6)
        {
            return false;
        }
    }

    return true;
}

//Main Function of the program. Plays the game.
void Play()
{
    Random random = new Random();
    string answer = string.Empty;   //The answer.
    string guess;                   //The user's guess.
    string hint;                    //The hint the user receives at the end of each turn.
    int plusCount;                  //The ammount of numbers in the correct position.
    int minusCount;                 //The ammount of numbers in that are in the answer but in the wrong position.

    //Assigns the answer to a random value.
    for (int i = 0; i < 4; i++)
    {
        answer += $"{random.Next(1, 7)}";
    }

    //The main game loop.
    for (int i = 0; i < 10; i++)
    {
        plusCount = 0;
        minusCount = 0;
        hint = string.Empty;

        //Asks the user to enter a guess and checks whether that guess is valid.
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Enter four numbers between 1 and 6 for your guess (example: 1234)");
            guess = Console.ReadLine();

            if (guess.Length != 4)
            {
                Console.WriteLine("Inncorrect length");
                Console.ReadKey();
            }
            else if (!int.TryParse(guess, out int unused))
            {
                Console.WriteLine("Please enter only numbers");
                Console.ReadKey();
            }
            else if(!CheckIfInRange(guess))
            {
                Console.WriteLine("Please only enter numbers between 1 and 6");
                Console.ReadKey();
            }
            else
            {
                break;
            }
        }

        //Checks if the guess is the answer. If it is then the player wins the game.
        if (guess == answer)
        {
            Console.WriteLine("You win!");
            Console.ReadKey();
            break;
        }

        //Checks which numbers are in the correct position and which are contained in the answer but in the wrong position.
        for (int position = 0; position < guess.Length; position++)
        {
            if (answer[position] == guess[position])
            {
                plusCount++;
                continue;
            }
            else if (answer.Contains(guess[position]))
            {
                minusCount++;
                continue;
            }
        }

        //Adds pluses and minuses to the hint.
        for (int plus = 0; plus < plusCount; plus++)
        {
            hint += "+";
        }
        for (int minus = 0; minus < minusCount; minus++)
        {
            hint += "-";
        }

        //If the last turn has passed the player loses and the answer is displayed. Otherwise the game loop continues.
        if (i == 9)
        {
            Console.WriteLine("You lost!");
            Console.WriteLine($"The answer was {answer}");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine($"{hint}\nPress any key to continue");
            Console.ReadKey();
        }
    }
}

Play();