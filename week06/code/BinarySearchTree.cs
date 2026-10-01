using System;
using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    public void Insert(int value)
    {
        if (_root is null)
            _root = new Node(value);
        else
            _root.Insert(value);
    }

    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Problem 3: Traverse Backwards
    /// </summary>
    public void TraverseBackward(List<int> results)
    {
        _root?.TraverseBackward(results);
    }

    public int GetHeight()
    {
        return _root != null ? _root.GetHeight() : 0;
    }

    public IEnumerable<int> Reversed()
    {
        var results = new List<int>();
        TraverseBackward(results);
        return results;
    }

    public IEnumerator<int> GetEnumerator()
    {
        var results = new List<int>();
        TraverseForward(_root, results);
        return results.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void TraverseForward(Node? node, List<int> results)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, results);
            results.Add(node.Data);
            TraverseForward(node.Right, results);
        }
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}
