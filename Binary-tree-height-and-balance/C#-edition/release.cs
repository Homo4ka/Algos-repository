using System;

// Узел дерева
public class TreeNode<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }

    public TreeNode(T value)
    {
        Value = value;
    }
}

// Бинарное дерево поиска
public class BinarySearchTree<T> where T : IComparable<T>
{
    private TreeNode<T> root;

    // Вставка значения в дерево
    public void Insert(T value)
    {
        root = InsertRecursive(root, value);
    }

    private TreeNode<T> InsertRecursive(TreeNode<T> node, T value)
    {
        if (node == null)
        {
            return new TreeNode<T>(value);
        }

        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = InsertRecursive(node.Left, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = InsertRecursive(node.Right, value);
        }

        return node;
    }

    // Обход дерева в порядке In-Order и вывод значений
    public void PrintInOrder()
    {
        PrintInOrderRecursive(root);
        Console.WriteLine();
    }

    private void PrintInOrderRecursive(TreeNode<T> node)
    {
        if (node != null)
        {
            PrintInOrderRecursive(node.Left);
            Console.Write(node.Value + " ");
            PrintInOrderRecursive(node.Right);
        }
    }

    public bool Contains(T value)
    {
        var current = root;

        while (current != null)
        {
            int cmp = value.CompareTo(current.Value);

            if(cmp == 0)
                return true;
            else if (cmp < 0)
                current = current.Left;
            else
                current = current.Right;
        }
        return false;
    }

    private TreeNode<T> RemoveValueRecursive(TreeNode<T> node, T value)
    {
        if (node == null)
            return null;

        var cmp = value.CompareTo(node.Value);
        if (cmp < 0)
            node.Left = RemoveValueRecursive(node.Left, value);
        else if (cmp > 0)
            node.Right = RemoveValueRecursive(node.Right, value);
        else
        {
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            var minNode = FindMin(node.Right);
            node.Value = minNode.Value;
            node.Right = RemoveValueRecursive(node.Right, minNode.Value);
        }
        
        return node;
    }

    private TreeNode<T> FindMin(TreeNode<T> node)
    {
        while (node.Left != null)
            node = node.Left;
        return node;
    }

    public void RemoveValue(T value)
    {
        root = RemoveValueRecursive(root, value);
    }

    private int GetHeightRecursive(TreeNode<T> node)
    {
        if (node == null)
            return 0;

        int leftH = GetHeightRecursive(node.Left);
        int rightH = GetHeightRecursive(node.Right);

        return 1 + Math.Max(leftH, rightH);
    }

    public int GetHeight()
    {
        return GetHeightRecursive(root);
    }

    private int CheckBalance(TreeNode<T> node)
    {
        if (node == null)
            return 0;

        var leftH = CheckBalance(node.Left);
        if (leftH < 0)
            return -1; //маркер дисбаланса

        var rightH = CheckBalance(node.Right);
        if (rightH < 0)
            return -1;

        if (Math.Abs(rightH - leftH) > 1) //если какое-то поддерево больше, на 1, по высоте листа 
            return -1;

        return 1 + Math.Max(leftH, rightH);
    }

    public bool IsBalanced()
    {
        return CheckBalance(root) != -1;
    }
}

class Program
{
    static void Main()
    {
        var tree = new BinarySearchTree<int>();

        // Заполняем дерево
        int[] values = { 5, 3, 8, 2, 4, 7, 9 };
        foreach (var v in values)
        {
            tree.Insert(v);
        }

        Console.Write("Элементы дерева (In-Order): ");
        tree.PrintInOrder(); // Ожидаемый вывод: 2 3 4 5 7 8 9

        Console.WriteLine("\nContains: ");
        Console.Write(tree.Contains(10));
        Console.Write(tree.Contains(4));

        Console.WriteLine("Removes:");
        tree.RemoveValue(4);
        tree.PrintInOrder();
        tree.RemoveValue(7);
        tree.PrintInOrder();
        tree.RemoveValue(3);
        tree.PrintInOrder();
        tree.RemoveValue(5);
        tree.PrintInOrder();
    }
}

/*
1) Поиск значения Напиши метод
bool Contains(T value)
. Он должен возвращать
true
, если значение есть в дереве, и
false
, если нет. Реализуй его итеративно (без рекурсии), чтобы не тратить лишнюю память на стек вызовов.

2) Удаление узла Добавь метод
void Remove(T value)
для удаления значения из дерева. Учитывай три случая:
У узла нет детей (листовой узел).

Есть дочерние узлы - сложный случай:
У узла один ребёнок.
У узла два ребёнка (тогда нужно найти наименьший элемент в правом поддереве и заменить им удаляемый узел).

3) Проверка баланса.
В конце основной программы добавь проверку: напиши метод int GetHeight() (высота дерева) и выведи её. Затем выведи сообщение о том, сбалансировано ли дерево (для простоты можно считать, что дерево сбалансировано, если разница высот левого и правого поддеревьев не больше 1 для каждого узла — это упрощённая проверка, не полная проверка AVL).
*/