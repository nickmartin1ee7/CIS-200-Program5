/*
 * Nicholas Martin (5111752)
 * 12/4/2022
 * CIS-200-75
 * Fall 2022
 * Program 5 EC
 *
 * Notes: I don't have the book, so I'll just write an API from the prompt description.
 */

while (true)
{
    Console.Clear();
    
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Demo int tree InOrder Traversal");
    Console.WriteLine("2. Demo double tree InOrder Traversal");
    Console.WriteLine("3. Just show me tree InOrder Traversal");
    Console.Write(">> ");

    var input = Console.ReadKey().KeyChar.ToString();
    Console.WriteLine();
    
    if (!int.TryParse(input, out var menuOption))
    {
        Console.WriteLine($"{input} is not a valid menu option. Try again!");
        Console.ReadKey();
        continue;
    }
    
    switch (menuOption)
    {
        case 0:
            Environment.Exit(0);
            break;
        case 1:
            DemoIntTree();
            break;
        case 2:
            DemoDoubleTree();
            break;
        case 3:
            QuickDemoIntTree();
            break;
        default:
            Console.WriteLine("That menu option does not exist. Try Again!");
            break;
    }

    Console.ReadKey();
}

void QuickDemoIntTree()
{
    var tree = new Tree<int>();
    int[] nums = { 9, 1, 5, 4, 8, 7, 3, 0, 2 };
    
    Console.WriteLine($"Creating a tree from: {string.Join(' ', nums)}");
    
    foreach (var num in nums)
    {
        tree.InsertNode(num);
    }

    Console.WriteLine("InOrder traversal:");
    tree.InOrderTraversal(Console.WriteLine);
}

void DemoIntTree()
{
    var tree = new Tree<int>();
    
    Console.Write("Enter an int or enter an empty line to finish.");
    Console.WriteLine();
    
    while (true)
    {
        Console.Write(">> ");

        var input = Console.ReadLine()?.Trim();
        if (int.TryParse(input, out var num))
        {
            tree.InsertNode(num);
        }
        else if (input == string.Empty)
        {
            tree.InOrderTraversal(Console.WriteLine);
            break;
        }
        else
        {
            Console.WriteLine("Invalid input: You need to enter a whole number. Try again!");
        }
    }
}

void DemoDoubleTree()
{
    var tree = new Tree<double>();

    Console.Write("Enter an double or enter an empty line to finish.");
    Console.WriteLine();
    
    while (true)
    {
        Console.Write(">> ");

        var input = Console.ReadLine()?.Trim();
        if (double.TryParse(input, out var num))
        {
            tree.InsertNode(num);
        }
        else if (input == string.Empty)
        {
            tree.InOrderTraversal(Console.WriteLine);
            break;
        }
        else
        {
            Console.WriteLine("Invalid input: You need to enter a floating-point number. Try again!");
        }
    }
}