using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them.
    // Expected Result: The item with the highest priority ("Item B", priority 5) should be dequeued first.
    // Defect(s) Found: The original loop condition (< _queue.Count - 1) skipped checking the last item in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item A", 2);
        priorityQueue.Enqueue("Item B", 5);
        priorityQueue.Enqueue("Item C", 3);

        var value = priorityQueue.Dequeue();
        Assert.AreEqual("Item B", value);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items where two items share the highest priority.
    // Expected Result: The item added first ("Item A") should be dequeued first (FIFO order for equal priorities).
    // Defect(s) Found: The original code used '>=' instead of '>', which selected the last added item instead of the first when priorities were equal.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item A", 5);
        priorityQueue.Enqueue("Item B", 5);
        priorityQueue.Enqueue("Item C", 2);

        var value = priorityQueue.Dequeue();
        Assert.AreEqual("Item A", value);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty Priority Queue.
    // Expected Result: InvalidOperationException should be thrown with message "The queue is empty.".
    // Defect(s) Found: None. The exception check in Dequeue() works as expected.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
        }
    }
}