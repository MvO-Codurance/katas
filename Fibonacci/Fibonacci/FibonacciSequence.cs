namespace Fibonacci;

public class FibonacciSequence
{
    public int NumberAtStep(int step)
    {
        if (step <= 0)
        {
            return 0;
        }
        
        int nMinus2 = 0;
        int nMinus1 = 1;
        int n = 1;

        for (int position = 1; position < step; position++)
        {
            n = nMinus1 + nMinus2;
            nMinus2 = nMinus1;
            nMinus1 = n;
        }

        return n;
    }
}