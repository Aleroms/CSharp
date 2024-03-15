using DiceGame;
var dice = new Dice();
var user = new User();
int maxTries = 3;

Console.WriteLine($"Dice rolled. Guess what number it is in {maxTries} tries.");
do
{
    int guess = user.GetInput();
    if (DiceValidator.Correct(guess))
    {
        break;
    }
    else
    {
        maxTries--;
        Console.WriteLine("Wrong number.");
    }
} while (maxTries > 0);
Console.WriteLine(maxTries > 0 ? "You win!" : "You lose :(");