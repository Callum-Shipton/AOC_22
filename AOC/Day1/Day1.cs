internal partial class Program
{
    private static void Day1()
    {
        const int numOfMaxElves = 3;

        var elfCals = new PriorityQueue<int, int>(numOfMaxElves);

        var currentElfCal = 0;

        foreach (var line in File.ReadLines("Day1/Input.txt"))
        {
            if (string.IsNullOrEmpty(line))
            {
                if (elfCals.Count == numOfMaxElves)
                    elfCals.EnqueueDequeue(currentElfCal, currentElfCal);
                else
                    elfCals.Enqueue(currentElfCal, currentElfCal);

                currentElfCal = 0;
            }
            else
            {
                currentElfCal += int.Parse(line);
            }
        }

        static (int max, int sum) GetCalDetails((int max, int sum) details, int cal) => (Math.Max(details.max, cal), details.sum + cal);

        var (max, sum) = elfCals.UnorderedItems.Select(x => x.Element)
                                               .Aggregate((0, 0), GetCalDetails);

        Console.WriteLine(max);
        Console.WriteLine(sum);
    }
}