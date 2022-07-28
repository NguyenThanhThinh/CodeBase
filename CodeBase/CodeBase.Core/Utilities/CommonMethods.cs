namespace CodeBase.Core.Utilities;

public class CommonMethods
{
    public static bool IsEmailValid(string email)
    {
        var patternEmail = $@"{Resources.Common.RegexEmail}";
        var regexEmail = new System.Text.RegularExpressions.Regex(patternEmail);
        return regexEmail.IsMatch(email);
    }

    public static bool IsPhoneNumberValid(string phone)
    {
        var patternPhone = $@"{Resources.Common.RegexPhoneNumber}";
        var regexPhone = new System.Text.RegularExpressions.Regex(patternPhone);
        return regexPhone.IsMatch(phone);
    }

    public static string GetEmptyStringIfNull(string? value)
    {
        if (value == null) return string.Empty;
        return value;
    }
}