using Microsoft.VisualStudio.TestTools.UnitTesting;
[TestClass]
public class PriorityQueueTests {
    [TestMethod]
    public void TestPriorityQueue_1() {
        var queue = new PriorityQueue();
        queue.Enqueue("Bas", 1);
        queue.Enqueue("Haut", 5);
        queue.Enqueue("Milieu", 3);
        Assert.AreEqual("Haut", queue.Dequeue());
    }
    [TestMethod]
    public void TestPriorityQueue_2() {
        var queue = new PriorityQueue();
        queue.Enqueue("Premier", 5);
        queue.Enqueue("Deuxieme", 5);
        Assert.AreEqual("Premier", queue.Dequeue());
    }
}
