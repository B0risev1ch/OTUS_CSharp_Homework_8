
public class TreeOperations
{

    public static void TraverseTree<T>(TreeNode<T> originNode)
    {
        Console.WriteLine("Traversing tree:");
        Traverse(originNode);
    }

    public static TreeNode<string> GenerateTree(int[] array)
    {
        var tree = new TreeNode<string>();

        foreach (var element in array)
        {
            //tree.AddNode(element);
        }

        return null;
    }

    public static void Traverse<T>(TreeNode<T> originNode)
    {
        if (originNode == null)
        {
            Console.WriteLine("Tree seems to be Empty!");
            return;
        }

        if (originNode.Left != null)
        {
            Traverse(originNode.Left);
        }
        Console.WriteLine($"{originNode.Name} - {originNode.Salary}");
        if (originNode.Right != null)
        {
            Traverse(originNode.Right);
        }

    }

    public static void DeleteFromTree(TreeNode<int> root)
    {
        Console.WriteLine("input item to delete");
        while (true)
        {
            var s = Console.ReadLine();
            var d = int.Parse(s);
            if (d == 0)
            {
                break;
            }
            FindAndDeleteNode(root, d);
        }
    }

    public static TreeNode<int> InputTree()
    {
        TreeNode<int> root = null;

        while (true)
        {
            Console.Write("Provide name (hit Enter to continue): ");
            var name = Console.ReadLine();
            if (name == String.Empty)
            {

                break;
            }

            Console.Write("Salary: $");

            int.TryParse(Console.ReadLine(), out var salary);
            if (salary < 0)
            {
                Console.WriteLine("what? try again");
                continue;
            }

            if (root == null)
            {
                root = new TreeNode<int>()
                {
                    Name = name,
                    Salary = salary
                };
            }
            else
            {
                AddNode(root, new TreeNode<int>()
                {
                    Name = name,
                    Salary = salary
                });
            }
        }

        return root;
    }

    public static void FindNumber(TreeNode<int> root)
    {
        Console.WriteLine("Enter Salary to find: ");

        int.TryParse(Console.ReadLine(), out var salary);

        var (node, level) = FindNode(root, salary, operationsCount: 0);

        if (node != null)
        {
            Console.WriteLine($"Found: {node.Name}");
        }
        else
        {
            Console.WriteLine($"такой сотрудник не найден");
        }
    }

    public static (TreeNode<int>, int) FindNode(TreeNode<int> root, int number, int operationsCount)
    {
        if (root == null)
        {
            Console.WriteLine("oopsie. The tree is empty");
            return (new TreeNode<int>(), 0); 
        }
        if (number < root.Salary)
        {
            //Ищем в левом поддереве
            if (root.Left != null)
            {
                return FindNode(root.Left, number, operationsCount + 1);
            }

            return (null, -1);
        }
        if (number > root.Salary)
        {
            //Ищем в правом поддереве
            if (root.Right != null)
            {
                return FindNode(root.Right, number, operationsCount + 1);
            }

            return (null, -1);
        }

        return (root, operationsCount + 1);
    }

    public static void AddNode(TreeNode<int>? rootNode, TreeNode<int> nodeToAdd)
    {


        if (nodeToAdd.Salary < rootNode.Salary)
        {
            //Добавляемый меньше корневого?
            //идем в левое поддерево
            if (rootNode.Left != null)
            {
                AddNode(rootNode.Left, nodeToAdd);
            }
            else
            {
                rootNode.Left = nodeToAdd;
            }
        }
        else
        {
            //Добавляемый больше или равен корневому?
            //идем в правое поддерево
            if (rootNode.Right != null)
            {
                AddNode(rootNode.Right, nodeToAdd);
            }
            else
            {
                rootNode.Right = nodeToAdd;
            }
        }
    }

    private static int GetMinValue(TreeNode<int> node)
    {

        if (node.Left != null)
        {
            return GetMinValue(node.Left);
        }
        return node.Salary;
    }

    public static TreeNode<int> FindAndDeleteNode(TreeNode<int> root, int value)
    {
        if (root == null) return root;

        if (value < root.Salary) //удаляемое меньше текущего
        {
            root.Left = FindAndDeleteNode(root.Left, value);
        }
        else if (value > root.Salary) //удаляемое больше текущего
        {
            root.Right = FindAndDeleteNode(root.Right, value);
        }
        else //удаляемое равно текущему 
        {
            //текущий узел - листовой
            if (root.Left == null && root.Right == null)
            {
                return null;
            }
            //текущий узел имеет только правый дочерний
            if (root.Left == null)
            {
                Console.WriteLine($"Удаление {value}");
                return root.Right;
            }
            //текущий узел имеет только левый дочерний
            if (root.Right == null)
            {
                Console.WriteLine($"Удаление {value}");
                return root.Left;
            }
            //текущий узел имеет два дочерних
            int minValue = GetMinValue(root.Right);
            root.Salary = minValue;
            root.Right = FindAndDeleteNode(root.Right, minValue);
            Console.WriteLine($"Значение {value} заменено на {minValue}");
        }

        return root;
    }
}
