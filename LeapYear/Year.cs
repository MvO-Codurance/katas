namespace LeapYear;

public class Year
{
    private readonly int _year;

    public Year(int year)
    {
        _year = year;
    }
    
    public bool IsLeap()
    {
        // not divisible by 4
        if (!DivisibleBy(_year, 4)) return false;
        
        // divisible by 100 but not divisible by 400
        if (DivisibleBy(_year, 100) && !DivisibleBy(_year, 400)) return false;
        
        // so at this point, year must be...
        // divisible by 4 and, if divisible by 100, also divisible by 400
        return true;
    }

    private bool DivisibleBy(int number, int divisor)
    {
        return (number % divisor) == 0;
    }
}