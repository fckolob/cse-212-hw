using System.Diagnostics.Metrics;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // Base case.
        if (Data == value)
        {
            return true;
        }

        // Case value lesser than data.
        else if (value < Data)
        {

            if (Left == null)
            {
                return false;
            }

            else
            {
                return Left.Contains(value);
            }

        }

        // Case value greater than data.
        else
        {
            if (Right == null)
            {
                return false;
            }

            else
            {
                return Right.Contains(value);
            }

        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // Base case.
        if (Left == null && Right == null)
        {
            return 1;
        }

        // Left subtree height.

        int leftHeight = 0;

        if (Left != null)
        {
            leftHeight = Left.GetHeight();
        }

        // Right subtree height.

        int rightHeight = 0;

        if (Right != null)
        {
            rightHeight = Right.GetHeight();
        }

        // Returning the height of the current node (1) + the max height of right or left subtree.

        return 1 + Math.Max(leftHeight, rightHeight);

    
    }
}