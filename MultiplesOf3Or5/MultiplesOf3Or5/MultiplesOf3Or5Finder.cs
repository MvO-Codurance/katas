namespace MultiplesOf3Or5;

public class MultiplesOf3Or5Finder
{
    public int SimpleSum(int limit)
    {
        int sum = 0;
        
        for (int i = 1; i < limit; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }
        
        return sum;
    }

    public int AlgorithmicSum(int limit)
    {
        /* The sum of of all numbers between 1 and n is:
         * n * (n + 1) / 2
         *
         * Also, the sum of numbers LESS THAN n that are divisible by d is:
         * d * ( (n/d) * ((n/d) + 1) ) / 2
         *
         * So, for numbers below 10 (i.e. 9):
         * Numbers divisible by 3 is: 3 * ( (9/3) * ((9/3) + 1) ) / 2
         * Numbers divisible by 5 is: 5 * ( (9/5) * ((9/5) + 1) ) / 2
         *
         * But the above sets will double count numbers that are divisible by BOTH 3 and 5.
         * So we then subtract from the above the set of numbers that are divisible by 15, i.e.:
         * 15 * ( (9/15) * ((9/15) + 1) ) / 2
         */

        int n = limit - 1;
        int divisibleBy3 = SumOfNumbersDivisibleBy(n, 3);
        int divisibleBy5 = SumOfNumbersDivisibleBy(n, 5);
        int divisibleBy15 = SumOfNumbersDivisibleBy(n, 15);

        return divisibleBy3 + divisibleBy5 - divisibleBy15;
    }

    private static int SumOfNumbersDivisibleBy(int n, int d)
    {
        return d * ((n / d) * ((n / d) + 1)) / 2;
    }
}