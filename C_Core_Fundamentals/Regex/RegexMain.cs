namespace C_Core_Fundamentals.Regex;

using System.Text.RegularExpressions;

/*
 * ^    starts with
 * $    ends with
 * []   range
 * ()   group
 * .    single char once
 * +    one or more chars
 * ?    optional preceding match
 * \    escape character
 * \n   newline
 * \d   digit
 * \D   NOT digit
 * \s   whitespace
 * \S   NOT whitespace
 * \w   alphanumeric/underscore character (word chars)
 * \W   non-word characters
 * {x,y}   Repeat low(x) to high (y) (no "y" means at least x, no ,y means that many
 * (x|y)    Alternate - x or y
 * [^x]     anything but x
 */
public static class RegexMain
{
    public static void MainMethod()
    {
        FindPhoneNumbersInFile();
        //ExampleMatchWithTim();
    }

    private static void FindPhoneNumbersInFile()
    {

        string searchString;
        try
        {
            searchString = File.ReadAllText("text.txt");
            
        }
        catch
        {
            searchString = @"440-555-1234, asdf lij Lorem Ipsum dolor sit amet, 
                           consectetur adipiscing 1-2.3 elit, sed do eiusmod tempor incididunt ut 
                            labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud 
                            exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor 
                            ";
        }

        string phoneNumberPattern = @"\d{3}[.-]?\d{3}[.-]?\d{4}";
        MatchCollection matches = Regex.Matches(searchString, phoneNumberPattern);

        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
    }
    
    private static void ExampleMatchWithTim()
    {
        string startsWithSpaceOrPattern = @"(\s|^)Tim\s.";
        string lowerOrCapitalTpattern = "[Tt]im";
        string endsWithWhitespaceOrPattern = "Tim(/s|$)";

        string pattern = @"(\s|$)Tim(\s|$)";
        
        "Tim Corey".MatchWithRegex(pattern);
        "Timothy Corey".MatchWithRegex(pattern);
        "Sometimes".MatchWithRegex(pattern);
        "I am Tim Corey".MatchWithRegex(pattern);
        "Always Tim".MatchWithRegex(pattern);
    }

    public static void MatchWithRegex(this string start, string pattern)
    {
        Console.WriteLine($"{start} IsMatch {pattern} : {System.Text.RegularExpressions.Regex.IsMatch(start, pattern)}");
    }
}