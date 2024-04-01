namespace DiceGame
{
    public class User
    {
        public int GetInput()
        {
            string userInput = "";
            int num;
            do
            {
                Console.WriteLine("Enter a number:");
                userInput = Console.ReadLine();

            } while (!int.TryParse(userInput, out num));
            return num;
        }
    }
}