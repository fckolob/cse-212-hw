public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        /// We create an array of doubles with a length equal to the argument passed to the length parameter.
        double[] multiplesResult = new double[length];

        
        /// We use a for loop to create multiples of the argument passed to the number parameter.
        /// We loop a number of times equal to the argument passed to the length parameter.
        /// Each time we add in the next available index a number that is the result of multiply the argument passed to the number parameter index + 1 times.
        for (var index = 0; index < length ; index++)
        {

            multiplesResult[index] = number * (index + 1);
        }
        
        /// We return the multiplesResult array of doubles.

        return multiplesResult;

        
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        /// We get the last elements of the list passed as an argument to the data parameter, we get a quantity of last elements equal to the number passed as an argument to the amount parameter and we store these elements in a new list called "sliced" using the GetRange method. We pass the difference between the data.Count property (the number of elements) and the number passed as an argument to the parameter amount as the index begin argument to the GetRange method and the number passed as an argument to the amount parameter as the end index argument to the GetRange method.
        var sliced = data.GetRange(data.Count - amount, amount);

        /// We remove the last "amount" elements from the data list using the RemoveRange method and passing the same arguments that we passed to the GetRange method previously.
        data.RemoveRange(data.Count - amount, amount);

        /// We insert the elements previously removed in the beginning of the data list using the InsertRange method, we pass a 0 as the beginning index argument and we pass the sliced list as the list of elements argument. 
        data.InsertRange(0, sliced);
    }
}
