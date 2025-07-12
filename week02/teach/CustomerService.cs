/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>


public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:



        // Test Cases

        // Test 1
        // Scenario:A new instance of the class CustomerService is created and a  customer is added using the terminal.
        // Expected Result: The value for the property Name of the first customer is expected to be the same introduced by the console, in this case: "Jhon".
        var cs = new CustomerService(10);
        cs.AddNewCustomer();
        string expectedResult = "Jhon";
        if (cs._queue[0].Name == expectedResult)
        {
            Console.WriteLine("Test 1 Passed");
        }
        else
        {
            Console.WriteLine("Test 1 Failed");
        }

        Console.WriteLine($"{cs}");

        // Defect(s) Found: No defects found

        Console.WriteLine("=================");

        // Test 2
        // Scenario: A new instance is created, but the max size is setted to 0, the method add customer should set the max size to 10 and the customers should be added in the proper order. 
        // Expected Result: 
        var cs1 = new CustomerService(0);
        cs1._queue.Add(new CustomerService.Customer("Mathew", "A1", "pc"));
        cs1._queue.Add(new CustomerService.Customer("Mark", "A2", "router"));
        cs1._queue.Add(new CustomerService.Customer("Luke", "A3", "screen"));
        string[] expectedResults = ["Mathew", "Mark", "Luke"];

        int tracker = 0;
        for (int i = 0; i < expectedResults.Length; i++)
        {
            if (cs1._queue[i].Name == expectedResults[i])
            {
                tracker += 1;
            }

        }



        Console.WriteLine($"{cs}");
        if (tracker == 3 && cs1._maxSize == 10)
        {
            Console.WriteLine("Test 2 Passed");
        }
        else
        {
            Console.WriteLine("Test 2 Failed");
        }

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3.
        //Scenario: We add 3 customers and then, we call the ServeCustomer method 4 times. 
        // Expected result: A invalid operation exeption should be throwed because the queue should be empty and a error message should be displayed.
        // Defects found: The ServeCustomer method was not checking if the queue was empty before try to access the 0 index of the queue and the exeption was not being handled.
        bool passed = false;
        var cs2 = new CustomerService(3);
        cs2._queue.Add(new CustomerService.Customer("Mathew", "A1", "pc"));
        cs2._queue.Add(new CustomerService.Customer("Mark", "A2", "router"));
        cs2._queue.Add(new CustomerService.Customer("Luke", "A3", "screen"));
        try
        {
            cs2.ServeCustomer();
            cs2.ServeCustomer();
            cs2.ServeCustomer();
            cs2.ServeCustomer();

        }
        catch (InvalidOperationException e)
        {
            if (e.Message == "The queue is empty")
            {
                passed = true;
            }
        }

        if (passed == true)
        {
            Console.WriteLine("Test 3 Passed");
        }
        else
        {
            Console.WriteLine("Test 3 Failed");
        }





        Console.WriteLine($"{cs2}");


        // Test 4.
        // Scenario: Three customers are added and then, the ServeCustomer method is executed once.
        // Expected result: When the ServeCustomer method is called, the customer at the front of the queue should be remove from the queue and then the second customer should be moved from the index position 1 to the index position 0.
        // Defects found: No defects found.
        var cs3 = new CustomerService(3);
        cs3._queue.Add(new CustomerService.Customer("Mathew", "A1", "pc"));
        cs3._queue.Add(new CustomerService.Customer("Mark", "A2", "router"));
        cs3._queue.Add(new CustomerService.Customer("Luke", "A3", "screen"));

        cs3.ServeCustomer();
        if (cs3._queue[0].Name == "Mark")
        {
            Console.WriteLine("Test 4 Passed");
        }
        else
        {
            Console.WriteLine("Test 4 Failed");
        }

        //Test 5.
        // Scenario: The AddNewCustomer method is executed one more time than the max capacity of the queue.
        // Expected result: A new invalid operation exeption should be throwed and an error message is displayed.
        // Defects found: The condition of the if statement for cheking if the queue is full was _queue.count > max_size, but should be _queue + 1 > max_size to avoid to add a customer when the queue is full. Also the method AddNewCustomer was not throwing a new invalid operation exeption.

        int times = 2;

        var cs4 = new CustomerService(times);
        bool passed1 = false;
        
         try
        {
         for (int i = 0; i < times + 1; i++)
         {
                cs4.AddNewCustomer();
         }   

        }
        catch (InvalidOperationException e)
        {
            if (e.Message == "The queue is full")
            {
                passed1 = true;
            }
        }

        if (passed1 == true)
        {
            Console.WriteLine("Test 5 Passed");
        }
        else
        {
            Console.WriteLine("Test 5 Failed");
        }



    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        public string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count + 1 > _maxSize)
        {
            throw new InvalidOperationException("The queue is full");
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }
        
        _queue.RemoveAt(0);
        
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }

            var customer = _queue[0];
            Console.WriteLine(customer);
        
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}