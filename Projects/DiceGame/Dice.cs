namespace DiceGame
{
    public class Dice
    {
        public static int Face { get; } = new Random().Next(1, 7);
        

    }
    public static class DiceValidator
    {
        public static bool Correct(int guess) =>  guess == Dice.Face;
        
    }
}