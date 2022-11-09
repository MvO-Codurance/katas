namespace MultiplesOf3Or5;

public class MultiplesOf3Or5Finder
{
    public int Sum(int limit)
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
}