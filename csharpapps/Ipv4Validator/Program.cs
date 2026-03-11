using IPvalidatorApp;

class Program
{
    public static void Main()
    {
        Console.WriteLine("--------IP VALIDATOR -----------");
        Console.Write("Enter the IPv4 Address: ");
        string input = Console.ReadLine();

        IPv4Address myIp = new IPv4Address(input);

        if(myIp.IsValid)
        {
            Console.WriteLine($"Status: Valid");
        } 
        else
        {
            Console.WriteLine("Status: Invalid IP Format");
        }
    }
}