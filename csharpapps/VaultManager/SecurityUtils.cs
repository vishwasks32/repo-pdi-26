namespace VaultManager.SecutrityUtils;

public static class SecurityUtils
{
    public static string GetHiddenInput()
    {
        string input = "";
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            if(keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
            {
                input += keyInfo.KeyChar;
                Console.Write("*");
            }
            else if ( keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input.Substring(0,(input.Length -1));
                Console.Write("\b \b");
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return input;
    }
}