using System;
namespace _20Questions
{
    public class _20Questions
    {
        public _20Questions(int magicnumber)
        {
            int num_tries = 20;
            int enters_out = 0;

            for (int enters = 0; enters < num_tries; enters++)
            {
                enters_out++;
                Console.WriteLine("Guess the numbers");
                string temp_guess = Console.ReadLine();
                int guess = Convert.ToInt32(temp_guess);

                if (guess < magicnumber)
                {
                    Console.WriteLine($"You're guess was too low. Try again. You have {num_tries-enters_out} tries left!");
                }
                else if (guess > magicnumber)
                {
                    Console.WriteLine($"You're guess was too high. Try again. You have {num_tries-enters_out} tries left!");
                }
                else if (guess == magicnumber)
                {
                    Console.WriteLine("You Win!");
                    break;
                }

                if (enters_out == num_tries)
                {
                    Console.WriteLine("You have no more guesses. You lose!");
                }
            }
        }
    }
}
