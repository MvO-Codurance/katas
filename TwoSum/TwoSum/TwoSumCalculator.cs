namespace TwoSum;

public class TwoSumCalculator
{
    public int[] Calculate(int[] input, int target)
    {
        for (int firstIndex = 0; firstIndex < input.Length; firstIndex++)
        {
            for (int secondIndex = 0; secondIndex < input.Length; secondIndex++)
            {
                if (firstIndex != secondIndex)
                {
                    if (input[firstIndex] + input[secondIndex] == target)
                    {
                        return new [] { firstIndex, secondIndex };
                    }
                }
            }
        }

        return new int[] { };
    }
    
    public int[] CalculateFaster(int[] input, int target)
    {
        for (int firstIndex = 0; firstIndex < input.Length; firstIndex++)
        {
            for (int secondIndex = firstIndex + 1; secondIndex < input.Length; secondIndex++)
            {
                if (firstIndex != secondIndex)
                {
                    if (input[firstIndex] + input[secondIndex] == target)
                    {
                        return new [] { firstIndex, secondIndex };
                    }
                }
            }
        }

        return new int[] { };
    }
}