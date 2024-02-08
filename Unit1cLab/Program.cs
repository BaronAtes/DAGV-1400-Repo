internal class Program
{
    private static void Main(string[] args)
    {
        int slotNum = 1; //Initializes count to compare with user input
        string myNum;
        Console.WriteLine("Enter a number:");
        int usrNum = Convert.ToInt32(Console.ReadLine());
        do //An outer loop starts here that stops the operation if the count reaches or exceeds the size of the user inputted number
        {
            myNum = ""; //Initializes string
            int count = 1; //Initiatlizes count for nested loop
            do
            {
                myNum = myNum + Convert.ToString(slotNum); //Converts slot number to a string, then adds it onto the string
                count++; //Increments nested loop count
            }
            while (slotNum >= count); //Breaks the nested loop if count exceeds the slot number
            slotNum++; //Increments slot number
            Console.WriteLine(myNum); //prints out result for this particular row
        }
        while (slotNum <= usrNum); //This is the end of both the outer loop and the program as a whole.
    }
}