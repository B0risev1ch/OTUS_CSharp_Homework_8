do
{
    var salaryTree = TreeOperations.InputTree();
    TreeOperations.Traverse(salaryTree);
    TreeOperations.FindNumber(salaryTree);

    Console.WriteLine("Wanna Play Again? 0 - yes, 1 - no");

} while (AskForPlayAgain());

static bool AskForPlayAgain()
{
    var answer = Console.ReadLine();
    if (answer == "0")
        return true;
    if (answer == "1")
        return false;
    return AskForPlayAgain();
}