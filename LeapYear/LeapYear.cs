namespace LeapYear;

public class LeapYear
{
    public bool IsLeapYear(int year)
    {
        // not divisible by 4
        if (year % 4 != 0) return false;
        
        // divisible by 100 but not divisible by 400
        if (year % 100 == 0 && year % 400 != 0) return false;
        
        // so at this point, year must be...
        // divisible by 4 and, if divisible by 100, also divisible by 400
        return true;
    }
}