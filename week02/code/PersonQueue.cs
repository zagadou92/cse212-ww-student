using System;
using System.Collections.Generic;

/// <summary>
/// A basic implementation of a FIFO Queue for Person objects.
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the back of the queue (FIFO).
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        // Correction : Add() insère à la fin de la liste (Back) au lieu de l'index 0.
        _queue.Add(person);
    }

    /// <summary>
    /// Remove and return the person from the front of the queue.
    /// </summary>
    public Person Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}