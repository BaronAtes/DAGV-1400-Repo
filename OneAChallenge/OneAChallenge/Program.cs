using System;

namespace OneAChallenge
{
    class MainClass
    {
        static public Challenger charOne;
        static public Challenger charTwo;
        public static Random rndOne = new Random();
        public static Random rndTwo = new Random();
        public static void Main(string[] args)
        {
            string wins = "And the winnder is..."; //String for victory text
            charOne = new Challenger(); //Player character is defined
            charTwo = new Challenger(); //Enemy character is defined

            charTwo.nym = "Sandbag"; //Adds name for enemy character
            charTwo.atk = rndOne.Next(1, 5);
            charTwo.def = rndTwo.Next(1, 5); //Both enemy stats are randomized

            Console.WriteLine("Enter player one's name");
            charOne.nym = Console.ReadLine(); //Allows the user to input their character's name
            charOne.atk = rndOne.Next(1, 5);
            charTwo.def = rndTwo.Next(1, 5);

            if (charOne.nym != null)
            {  //Win conditions begin here
                if (charOne.atk > charTwo.def)
                {
                    Console.WriteLine(wins);
                    Console.WriteLine(charOne.nym);
                }
                else if (charTwo.atk > charOne.def)
                {
                    Console.WriteLine(wins);
                    Console.WriteLine(charTwo.nym); //The first two win conditions check if the attack stat is higher than the enemy's defense, whoever has the higher attack wins
                }
                else if (charOne.def > charTwo.def)
                {
                    Console.WriteLine(wins);
                    Console.WriteLine(charOne.nym);
                }
                else if (charTwo.def > charOne.def)
                {
                    Console.WriteLine(wins);
                    Console.WriteLine(charTwo.nym); //Second win condition, in which characters can out-endure the other by having a higher defense stat.
                }
                else
                    Console.WriteLine("It's a draw!"); //If neither win condition happens, the match ends in a draw. Pretty much only happens when both characters have the same stats.
            }
        }
    }
}

public class Challenger //Defines the class Challenger, which is used for characters
{
    public string nym; //The name of the character
    public int def; //The character's Attack stat
    public int atk; //The character's defense stat
}