internal partial class Program
{
    private static void Day2()
    {
        var totalRequestedMovePoints = 0;
        var totalRequestedOutcomePoints = 0;
        foreach (var round in File.ReadLines("Day2/Input.txt"))
        {
            var choices = round.Split(' ');
            totalRequestedMovePoints += RequestedMoveStrategyPoints(choices[0], choices[1]);
            totalRequestedOutcomePoints += RequestedOutcomeStrategyPoints(choices[0], choices[1]);
        }

        Console.WriteLine(totalRequestedMovePoints);
        Console.WriteLine(totalRequestedOutcomePoints);
    }

    private static int RequestedMoveStrategyPoints(string opponent, string mine)
    {
        return (opponent, mine) switch
        {
            ("B", "X") => 1,
            ("C", "Y") => 2,
            ("A", "Z") => 3,
            ("A", "X") => 4,
            ("B", "Y") => 5,
            ("C", "Z") => 6,
            ("C", "X") => 7,
            ("A", "Y") => 8,
            ("B", "Z") => 9,
            _ => throw new InvalidDataException("Unknown strategy")
        };
    }

    private static int RequestedOutcomeStrategyPoints(string opponent, string mine)
    {
        return (opponent, mine) switch
        {
            ("B", "X") => 1,
            ("C", "X") => 2,
            ("A", "X") => 3,
            ("A", "Y") => 4,
            ("B", "Y") => 5,
            ("C", "Y") => 6,
            ("C", "Z") => 7,
            ("A", "Z") => 8,
            ("B", "Z") => 9,
            _ => throw new InvalidDataException("Unknown strategy")
        };
    }
}