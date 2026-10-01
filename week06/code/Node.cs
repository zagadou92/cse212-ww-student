using System;
using System.Collections.Generic;

public class Node
{
    public int Data { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int data)
    {
        Data = data;
    }

    /// <summary>
    /// Problem 1: Insert Unique Values Only
    /// </summary>
    public void Insert(int value)
    {
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Contains
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }

        if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }
        else
        {
            return Right != null && Right.Contains(value);
        }
    }

    /// <summary>
    /// Problem 3: Traverse Backwards
    /// </summary>
    public void TraverseBackward(List<int> results)
    {
        Right?.TraverseBackward(results);
        results.Add(Data);
        Left?.TraverseBackward(results);
    }

    /// <summary>
    /// Problem 4: Tree Height
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left != null ? Left.GetHeight() : 0;
        int rightHeight = Right != null ? Right.GetHeight() : 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
