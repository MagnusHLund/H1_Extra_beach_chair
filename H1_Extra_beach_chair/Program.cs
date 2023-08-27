namespace H1_Extra_beach_chair
{
    internal class Program
    {
        static void Main()
        {
            Controller();
        }

        #region Controllers

        static void Controller()
        {
            // Creates a random class variable, for getting either a 0 or 1
            Random random = new Random();

            while (true)
            {
                // Array called "options" with 3 options. Those are 0, 1 or space.
                char[] options = { '0', '1', ' '};

                // Array for the result, which is what gets output into the console as well as used for figuring out the available seats
                char[] result = new char[61];

                // Counter variable to keep track of every time the x for loop repeats, without resetting the value like it does to the int x
                int counter = 0;

                // For loop for the vertical axis
                for(int y = 0; y < 6 ; y++)
                {
                    // For loop for the horizontal axis
                    for (int x = 0; x < 10; x++)
                    {
                        // Counter increases by 1 and the position as counter is inside result becomes either 0 or 1
                        counter++;
                        result[counter] = options[random.Next(0, 2)];

                        // if its the end of the x for loop then it creates a space character
                        if (x == 9)
                        {
                            result[counter] = options[2];
                        }

                        // Outputs the seats horizontally
                        Message($"{result[counter]}");
                    }

                    // Goes to the next vertical line
                    MessageLine("");
                }

                // Creates an int called "seats" which works like a counter
                int seats = 0;

                // For loop which repeats until the counter value is reached
                for(int i = 0; i < counter; i++)
                {
                    // if its the first or last value then it wont run the insides of this if statement
                    if (i != 0 && i != 59)
                    {
                        // Checks if there arent any 1's around the "i" location, as well as "i" not being being a space
                        if (result[i] != '1' && result[i-1] != '1' && result[i+1] != '1' && result[i] != ' ')
                        {
                            // If only spaces or 0's is "i" or around "i" then seats increases by 1
                            seats++;
                        }
                    }
                }

                // Creates a line space and outputs the available seats value as well as some other text
                MessageLine("");
                MessageLine("Available seats:");
                Seats(seats);
                MessageLine("Press Enter to repeat");

                // Waits for the user to press enter, then repeats the while loop
                Console.ReadLine();
            }

        }

        #endregion

        #region Views
        
        /// <summary>
        /// Used for outputting normal messages, which writes on a new line
        /// </summary>
        /// <param name="message"></param>
        static void MessageLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Used for outputting normal messages, which writes on the same line as the previous output was on
        /// </summary>
        /// <param name="message"></param>
        static void Message(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Used to output the seats value
        /// </summary>
        /// <param name="seats"></param>
        static void Seats(int seats)
        {
            Console.WriteLine(seats);
        }

        #endregion
    }
}