public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static List<int> ListSelector(int[] list1, int[] list2, int[] select)
    {
        int traker1 = 0;
        int traker2 = 0;
        var results = new List<int>();

        for (var index = 0; index < select.Length; index++)
        {
            if (select[index] == 1)
            {
                results.Add(list1[traker1]);
                traker1 += 1;
            }
            else
            {
                results.Add(list2[traker2]);
                traker2 += 1;
            }
        }
        return results;
    }
}