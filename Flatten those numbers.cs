class Task2
{
    static void Main()
    {
        object[] jaggedArray = 
        {
            6410, 2831, 5049, 7554,
            new object[] 
            {
                8707, 6940, 9517, 7565, 7522, 9242, 7972, 7064, 3441,
                new object[] 
                {
                    9960, 4966, 9368, 1634, 5150, 3709, 6660,
                    new object[] 
                    {
                        7155, 8056, 7834, 2639, 6601, 8063, 2390, 2544, 7022
                    }
                },
                2385, 573, 656, 733, 1620, 3626,
                new object[] 
                {
                    6274, 1935, 
                    new object[] { 6481, 928, 8291, 3196, 3431, 6058 },
                    8010, 5052, 892, 3490, 2369, 951, 1606, 6763, 7260, 6122
                }
            },
            5655, 4223
        };

        List<int> flattenedList = FlattenArray(jaggedArray);
        
        foreach (int num in flattenedList)
        {
            Console.Write(num + " ");
        }
    }

    static List<int> FlattenArray(object[] arr)
    {
        List<int> result = new List<int>();
        foreach (var item in arr)
        {
            if (item is int)
            {
                result.Add((int)item);
            }
            else if (item is object[])
            {
                result.AddRange(FlattenArray((object[])item));
            }
        }
        return result;
    }
}