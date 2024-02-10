internal class Program
{
    private static void Main(string[] args)
    {
        Random rnd = new Random(); //Initialized an instance of the Random class, allowing the program to generate random numbers.
        int compNum = rnd.Next(1, 11); //Generates the number the computer is thinking of, which will always be at least 1 and under 11.
        int usrTries = 1; //Initiates the number of attempts the user has made. Since success does not incriment the number, it always starts at 1.
        Console.WriteLine("I'm thinking of a number between 1 and 10.");
        Console.WriteLine("Input your guess for what number I'm thinking of below:");  //Text for user prompt
        int usrNum = Convert.ToInt32(Console.ReadLine()); //Converts what the user typed into an integer that can be compared to the computer's
        if (usrNum != compNum) //Checks if the user's number is not equal to the computer's
        {
            do //After it checks if the user's number isn't equal to the computer's, it enters a loop so long as that is the case.
            {
                if (usrNum > compNum) //Checks if the user's number is too high so that it can send out a proper message to help them guess.
                {
                    Console.WriteLine("Your number is too high! Guess again below:");
                    usrNum = Convert.ToInt32(Console.ReadLine()); //Re-initializes user number
                    usrTries++; //Incriments the number of tries by 1
                } 
                else //Same as above, but for when the user's number is too low.
                {
                    Console.WriteLine("Your number is too low! Guess again below:");
                    usrNum = Convert.ToInt32(Console.ReadLine());
                    usrTries++;
                }

            }
            while (usrNum != compNum); //End of loop
        }
        Console.WriteLine("Congratulations! You did it!");
        Console.WriteLine("My number is: " + compNum); //Displays the computer's number
        Console.WriteLine("Number of tries: " + usrTries); //Displays the number of attempts that the user made.
    }
}