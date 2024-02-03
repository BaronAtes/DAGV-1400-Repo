internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter the current temperature (in celcius):"); //Displays the phrase in quotation marks on the console
        int temp = Convert.ToInt32(Console.ReadLine()); //Takes the user's input and converts it into a number that the system can use
        if (temp >= 30) //Checks if the temperature is equal to or greater to 30 degrees, and runs the following code if so
        {
            Console.WriteLine("It's really hot! Be sure to stay hydrated and don't stay in the sun for too long!");
        }
        else if (temp <= 10)
        {
            Console.WriteLine("It's really cold! Be sure to wear cold clothing!");
        }
        else if (temp <= 20)
        {
            Console.WriteLine("It's a bit chilly out there. Be sure to wear a light jacket!");
        }
        else //This portion of code runs if the temperature is NOT equal to or greater than 30.
        {
            Console.WriteLine("Enjoy the pleasant weather!");
        }
    }
}