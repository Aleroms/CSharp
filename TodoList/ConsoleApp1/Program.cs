string userInput = "";
var todoItems = new List<string>();
Console.WriteLine("Hello!\n");
do
{

    userInput = SelectOption();
    switch (userInput)
    {
        case "s": //show todo items
            DisplayItems();
            break;
        case "a": // add todo item
            AddItem();
            break;
        case "r": // remove a todo item
            RemoveItem();
            break;
    }


} while (userInput != "e");

string SelectOption()
{
    string input = "";
    do
    {
        DisplayOptions();
        input = Console.ReadLine().ToLower();

        if (!IsValidInput(input))
            Console.WriteLine("Invalid choice.\n");

    } while (!IsValidInput(input));
    return input;
}
void DisplayOptions()
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S] - see all TODO items");
    Console.WriteLine("[A] - add an item");
    Console.WriteLine("[R] - remove an item");
    Console.WriteLine("[E] - exit");
}
void DisplayItems()
{
    if (todoItems.Count == 0) { Console.WriteLine("todo list is empty.\n"); return; }

    for (int i = 0; i < todoItems.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todoItems[i]}");
    }
    Console.WriteLine("");
}
void AddItem()
{
    bool validItem = false;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        string todo = Console.ReadLine();
        if (todo.Length == 0) DisplayEmptyInputError("The description");
        else if (todoItems.Contains(todo)) Console.WriteLine("The description must be unique.");
        else
        {
            todoItems.Add(todo);
            Console.WriteLine($"Todo successfully added: {todo}\n");
            validItem = true;
        }
    } while (!validItem);


}
void RemoveItem()
{
    if (todoItems.Count == 0) { Console.WriteLine("no items in TODO"); return; }
    bool validItem = false;
    int maxLength = todoItems.Count;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove");
        DisplayItems();
        string userInput = Console.ReadLine();
        int index = 0;
        if (userInput.Length == 0) DisplayEmptyInputError("Selected index");
        else if (!int.TryParse(userInput, out index)) Console.WriteLine("The given index is not valid.");
        else if (index < 0 || index > maxLength) Console.WriteLine("The given index is not valid.");
        else
        {
            var item = todoItems[index - 1];
            todoItems.Remove(item);
            Console.WriteLine($"TODO removed: {item}\n");
            validItem = true;
        }
    } while (!validItem);


}
void DisplayEmptyInputError(string msg)
{
    Console.WriteLine($"{msg} cannot be empty.");
}
bool IsValidInput(string input)
{
    return input == "s" || input == "a" || input == "r" || input == "e";
}