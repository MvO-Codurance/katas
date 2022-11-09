namespace Fibonacci;

public class FibonacciSequence
{
    public int NumberAtStep(int step)
    {
        // c = a + b
        // where the numbers are in sequential positions a, b, and c
        
        if (step <= 0)
        {
            return 0;
        }
        
        int a = 0;
        int b = 1;
        int c = a + b;

        for (int position = 1; position < step; position++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return c;
    }
    
    public int NumberAtStepRecursive(int step)
    {
        if (step is 0 or 1)  
        {  
            return step;  
        }

        return NumberAtStepRecursive(step - 1) + NumberAtStepRecursive(step - 2);
    }
}