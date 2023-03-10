namespace RomanNumerals;

public class RomanNumeralConverter
{
    private static readonly List<ArabicToRomanNumeral> ArabicToRomanNumerals; 
        
    static RomanNumeralConverter()
    {
        ArabicToRomanNumerals = new List<ArabicToRomanNumeral>
        {
            new ArabicToRomanNumeral(1000, "M"),
            new ArabicToRomanNumeral(900, "CM"),
            new ArabicToRomanNumeral(500, "D"),
            new ArabicToRomanNumeral(400, "CD"),
            new ArabicToRomanNumeral(100, "C"),
            new ArabicToRomanNumeral(90, "XC"),
            new ArabicToRomanNumeral(50, "L"),
            new ArabicToRomanNumeral(40, "XL"),
            new ArabicToRomanNumeral(10, "X"),
            new ArabicToRomanNumeral(9, "IX"),
            new ArabicToRomanNumeral(5, "V"),
            new ArabicToRomanNumeral(4, "IV"),
            new ArabicToRomanNumeral(1, "I")
        };
    }
    
    public string RomanNumeralFor(int arabic)
    {
        string result = string.Empty;
        
        foreach (ArabicToRomanNumeral arabicToRomanNumeral in ArabicToRomanNumerals)
        {
            while (arabic >= arabicToRomanNumeral.Arabic)
            {
                result += arabicToRomanNumeral.RomanNumeral;
                arabic -= arabicToRomanNumeral.Arabic;
            }
        }

        return result;
    }

    private record struct ArabicToRomanNumeral(int Arabic, string RomanNumeral);
}