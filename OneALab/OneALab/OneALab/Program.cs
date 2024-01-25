using System;
using MyLibrary;
namespace OneALab
{
    class OneALab
    {
        public static void Main(string[] args)
        {
            int coolNum = 15; //Initializes CoolNum as 15
            string coolText = "If this is the output you're given something went wrong."; //Initializes coolText
            if (coolNum % 2 == 0)
            {
                coolText = "There is no remainder? How?";
            }
            else
            {
                coolText = "There is a remainder. Move along.";
            } //Checks if the remainder is 0 or not, and changes coolText accordingly.
            Console.WriteLine(coolText); //Writes cooltext to console
        }
    }
}
