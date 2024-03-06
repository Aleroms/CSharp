int firstNumber = -1;
int secondNumber = -1;
Console.WriteLine("Hello!\nInput first number:");
firstNumber = GetUserInput();
Console.WriteLine("Input second number:");
secondNumber = GetUserInput();
Console.WriteLine("What do you want to do?");
DisplayOptions();
string userOption = GetUserOption();

DealWithOperation(userOption, firstNumber, secondNumber);
//EOF
Console.WriteLine("Press any key to continue...");
Console.ReadKey();


void DealWithOperation(string u, int fn, int sn)
{
    string operand = u == "a" ? "+" : u == "s" ? "-" : "*";
    int res = u == "a" ? (fn + sn) : u == "s" ? (fn - sn) : (fn * sn);
    Console.WriteLine(fn + " " + operand + " " + sn + " = " + res);
}
int GetUserInput()
{
    string userInput = Console.ReadLine();
    int number = 0;
    while (!int.TryParse(userInput, out number))
    {
        Console.WriteLine("Invalid. Please try again.");
        userInput = Console.ReadLine();
    }
    return number;
}
string GetUserOption()
{
    string option = Console.ReadLine().ToLower();
    //string option = o.ToLower();
    while(option != "a" && option != "s" && option != "m")
    {
        Console.WriteLine("Invalid. Please try again.");
        option = Console.ReadLine().ToLower();
    }
    return option;
}

void DisplayOptions()
{
    Console.WriteLine("[A] - add numbers");
    Console.WriteLine("[S] - subtract numbers");
    Console.WriteLine("[M] - multiply numbers");
}