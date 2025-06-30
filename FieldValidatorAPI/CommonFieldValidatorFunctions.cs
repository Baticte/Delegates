using System.Text.RegularExpressions;

namespace FieldValidatorAPI;

    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int minLength, int maxLength);
    public delegate bool DateValidDel(DateTime fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);

public class CommonFieldValidatorFunctions
{
    private static RequiredValidDel _requiredValidDel = null;
    private static StringLengthValidDel _stringLengthValidDel = null;
    private static DateValidDel _dateValidDel = null;
    private static PatternMatchDel _patternMatchDel = null;
    private static CompareFieldsValidDel _compareFieldsValidDel = null;

    public static RequiredValidDel RequiredFieldValidDel
    {
        get { return _requiredValidDel ??= new RequiredValidDel(RequiredFieldValid); }
    }
    
    private static bool RequiredFieldValid(string fieldVal)
    {
        return !string.IsNullOrEmpty(fieldVal);
    }
    
    private static bool StringLengthFieldValid(string fieldVal, int minLength, int maxLength)
    {
        return fieldVal.Length >= minLength && fieldVal.Length <= maxLength;
    }
    
    private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
    {
        return DateTime.TryParse(dateTime, out validDateTime);
    }

    private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
    {
        var regex = new Regex(regularExpressionPattern);
        
        return regex.IsMatch(fieldVal);
    }
    
    private static bool CompareFieldsValid(string fieldVal1, string fieldVal2)
    {
        return fieldVal1 == fieldVal2;
    }
}