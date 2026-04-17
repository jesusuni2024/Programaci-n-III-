using System;

class Node
{
    public int Value;
    public Node Left;
    public Node Right;
    public int Height;

    public Node(int value)
    {
        Value = value;
        Height = 1;
    }
}

class AVLTree
{
    private Node root;

    private int Height(Node node)
    {
        return node == null ? 0 : node.Height;
    }

    private int GetBalance(Node node)
    {
        return node == null ? 0 : Height(node.Left) - Height(node.Right);
    }

    private int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    private Node RotateRight(Node y)
    {
        Node x = y.Left;
        Node temp = x.Right;

        x.Right = y;
        y.Left = temp;

        y.Height = Max(Height(y.Left), Height(y.Right)) + 1;
        x.Height = Max(Height(x.Left), Height(x.Right)) + 1;

        return x;
    }

    private Node RotateLeft(Node x)
    {
        Node y = x.Right;
        Node temp = y.Left;

        y.Left = x;
        x.Right = temp;

        x.Height = Max(Height(x.Left), Height(x.Right)) + 1;
        y.Height = Max(Height(y.Left), Height(y.Right)) + 1;

        return y;
    }

    public void Insert(int value)
    {
        root = Insert(root, value);
    }

    private Node Insert(Node node, int value)
    {
        if (node == null)
            return new Node(value);

        if (value < node.Value)
            node.Left = Insert(node.Left, value);
        else if (value > node.Value)
            node.Right = Insert(node.Right, value);
        else
            return node;

        node.Height = 1 + Max(Height(node.Left), Height(node.Right));

        int balance = GetBalance(node);

        // Caso LL
        if (balance > 1 && value < node.Left.Value)
            return RotateRight(node);

        // Caso RR
        if (balance < -1 && value > node.Right.Value)
            return RotateLeft(node);

        // Caso LR
        if (balance > 1 && value > node.Left.Value)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        // Caso RL
        if (balance < -1 && value < node.Right.Value)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    public void InOrder()
    {
        InOrder(root);
        Console.WriteLine();
    }

    private void InOrder(Node node)
    {
        if (node != null)
        {
            InOrder(node.Left);
            Console.Write(node.Value + " ");
            InOrder(node.Right);
        }
    }
}

class Program
{
    static void Main()
    {
        AVLTree tree = new AVLTree();

        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(10);
        tree.Insert(25);
        tree.Insert(40);
        tree.Insert(50);

        Console.WriteLine("Recorrido en orden del árbol AVL:");
        tree.InOrder();
    }
}