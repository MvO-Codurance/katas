namespace TwoSum;

public class TwoSumCalculator
{
    public long[] Calculate(long[] input, long target)
    {
        for (int firstIndex = 0; firstIndex < input.Length; firstIndex++)
        {
            for (int secondIndex = 0; secondIndex < input.Length; secondIndex++)
            {
                if (firstIndex != secondIndex)
                {
                    if (input[firstIndex] + input[secondIndex] == target)
                    {
                        return new long[] { firstIndex, secondIndex };
                    }
                }
            }
        }

        return new long[] { };
    }
}