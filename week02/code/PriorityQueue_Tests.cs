using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding five items with different priority level.
    // Expected Result: The expected result is to get the items with higher priority first by the Enqueue method if the PriorityQueue class.
    // Defect(s) Found: the method Enqueue was not iterating through all the queue because the loop was being executed while the index is lower than _queue.Count 1 1 and the index is initialized at 1. The for loop should work until index < _queue.Count.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Dylan", 3);
        priorityQueue.Enqueue("George", 2);
        priorityQueue.Enqueue("Michael", 1);
        priorityQueue.Enqueue("Seru", 8);
        priorityQueue.Enqueue("Ray", 7);

        string[] expectedResult = ["Seru", "Ray", "Dylan", "George", "Michael"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(item, expectedResult[i]);
        }


    }

    [TestMethod]
    // Scenario:Five items are added and some of them have the same priority level.
    // Expected Result: The expected result is to get the items with the higher priority level and if there are items with the same priority level, then should be returned the item closer to the front, meaning with the lower index.
    // Defect(s) Found: The Dequeue method of the class PriorityQueue was not mannaging the case of items having the same priority level. The problem was the use of ">=" in the loop for getting the index of the item with the highest priority level, in the case of items with the same priority level was not returned the first item with this priority level, but the last, insted should be used ">" for getting the first item with the highest priority level.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Dylan", 3);
        priorityQueue.Enqueue("George", 2);
        priorityQueue.Enqueue("Michael", 3);
        priorityQueue.Enqueue("Seru", 8);
        priorityQueue.Enqueue("Ray", 2);

        string[] expectedResult = ["Seru", "Dylan", "Michael", "George", "Ray"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(item, expectedResult[i]);
        }
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Trying to Dequeue an item when the queue is empty.
    // Expected Result: A new Exception is thrown and the message defined in the Dequeue method of the PriorityQueue class.
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_Empty()
    {
        var items = new PriorityQueue();

        try
        {
            items.Dequeue();
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
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}