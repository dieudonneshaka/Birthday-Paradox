using System;

class BirthdayParadox
{
    static Random rand = new Random();

    // Simulate a birthday paradox for a given group size
    static bool HasMatchingBirthday(int groupSize)
    {
        // Create an array to represent the birthdays of people in the group
        int[] birthdays = new int[groupSize];

        // Assign random birthdays (1 to 365) to each person
        for (int i = 0; i < groupSize; i++)
        {
            birthdays[i] = rand.Next(1, 366); // Random number between 1 and 365
        }

        // Check if there are any duplicate birthdays
        return birthdays.Distinct().Count() < groupSize;
    }

    // Calculate the probability for a given group size by running multiple trials
    static double CalculateProbability(int groupSize, int trials)
    {
        int matches = 0;

        // Run the simulation for the specified number of trials
        for (int i = 0; i < trials; i++)
        {
            if (HasMatchingBirthday(groupSize))
            {
                matches++;
            }
        }

        // Return the probability of a match occurring
        return (double)matches / trials;
    }

    static void Main()
    {
        // Number of trials to run for each group size
        int trials = 10000;

        // Try different group sizes and calculate the probability of a match
        for (int groupSize = 2; groupSize <= 100; groupSize++)
        {
            double probability = CalculateProbability(groupSize, trials);
            Console.WriteLine($"Group Size: {groupSize}, Probability of a Match: {probability:P2}");
        }
    }
}
